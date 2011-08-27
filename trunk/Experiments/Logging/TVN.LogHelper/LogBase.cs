using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using log4net;
using log4net.Config;

namespace TVN.LogHelper
{
    /// <summary>
    /// Provides methods for logging
    /// </summary>
    public sealed class LogBase
    {
        private const uint DefaultKey = 0;
        private static bool _isConfigured = false;

        private static object _syncLoggers = new object();
        /// <summary>
        /// Contains all loggers for all Type that call StepIn/StepOut
        /// </summary>
        private static Dictionary<Type, ILog> _loggers = new Dictionary<Type, ILog>();

        private static object _syncMethods = new object();
        /// <summary>
        /// Contains started time for methods to log
        /// </summary>
        private static Dictionary<MethodBase, Dictionary<UInt32, DateTime>> _stepInDates = new Dictionary<MethodBase, Dictionary<UInt32, DateTime>>();

        #region Configure

        /// <summary>
        /// Configures logging policy.
        /// </summary>
        /// <param name="configFile">Path the file contains log parameters</param>
        public static void Configure(string configFile)
        {
            if (!_isConfigured)
            {
                XmlConfigurator.Configure(new FileInfo(configFile));
                _isConfigured = true;
            }
        }

        /// <summary>
        /// Configures logging policy.
        /// </summary>
        /// <param name="configStream">The stream of file contains log parameters</param>
        public static void Configure(Stream configStream)
        {
            if (!_isConfigured)
            {
                XmlConfigurator.Configure(configStream);
                _isConfigured = true;
            }
        }

        #endregion

        #region StepIn

        /// <summary>
        /// Starts record information to log.
        /// </summary>
        /// <param name="method">Current executing method</param>
        public static void StepIn(MethodBase method)
        {
            LogBase.StepIn(method, DefaultKey);
        }

        /// <summary>
        /// Starts record information to log. Uses this method if you want to log many times in your source method.
        /// </summary>
        /// <param name="method">Current executing method</param>
        /// <param name="callId">Use to identify place of calling in one method</param>
        public static void StepIn(MethodBase method, UInt32 callId)
        {
            // Create loger
            lock (_syncLoggers)
            {
                if (!_loggers.ContainsKey(method.DeclaringType))
                {
                    _loggers.Add(method.DeclaringType, LogManager.GetLogger(method.DeclaringType));
                }
            }

            // Set start time
            lock (_syncMethods)
            {
                if (!_stepInDates.ContainsKey(method))
                {
                    _stepInDates.Add(method, new Dictionary<uint, DateTime>());
                }
                if (_stepInDates[method].ContainsKey(callId))
                {
                    _stepInDates[method][callId] = DateTime.Now;
                }
                else
                {
                    _stepInDates[method].Add(callId, DateTime.Now);
                }
            }

            // Write debug information
            lock (_syncLoggers)
            {
                _loggers[method.DeclaringType].DebugFormat("=> {0} ({1}) starts at {2}", method.Name, callId, _stepInDates[method][callId]);
            }
        }

        #endregion

        #region StepOut

        /// <summary>
        /// Logs recorded information.
        /// </summary>
        /// <param name="method">Current executing method</param>
        public static void StepOut(MethodBase method)
        {
            LogBase.StepOut(method, DefaultKey);
        }

        /// <summary>
        /// Logs recorded information. Uses this method if you want to log many times in your source method.
        /// </summary>
        /// <param name="method">Current executing method</param>
        /// <param name="callId">Use to identify place of calling in one method</param>
        public static void StepOut(MethodBase method, UInt32 callId)
        {
            lock (_syncLoggers)
            {
                if (_loggers.ContainsKey(method.DeclaringType))
                {
                    lock (_syncMethods)
                    {
                        if (_stepInDates.ContainsKey(method) && _stepInDates[method].ContainsKey(callId))
                        {
                            TimeSpan elapsedTime = DateTime.Now - _stepInDates[method][callId];
                            _loggers[method.DeclaringType].DebugFormat("<= {0} ({1}) takes time in {2}{3}", method.Name, callId, elapsedTime, Environment.NewLine);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
