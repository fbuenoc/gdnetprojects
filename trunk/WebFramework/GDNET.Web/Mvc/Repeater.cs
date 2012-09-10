﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GDNET.Utils;
using GDNET.Web.Common;

namespace GDNET.Web.Mvc
{
    public class Repeater<T>
    {
        private List<string> columns = new List<string>();
        private List<T> entities = new List<T>();
        private Dictionary<string, Func<T, string>> generators = new Dictionary<string, Func<T, string>>();

        public Repeater()
        {
            this.Name = "rpt";
            this.EnableHeader = true;
        }

        #region Properties

        public string Name { get; set; }
        public bool EnableHeader { get; set; }

        public ReadOnlyCollection<string> Columns
        {
            get { return new ReadOnlyCollection<string>(this.columns); }
        }

        public ReadOnlyCollection<T> Entities
        {
            get { return new ReadOnlyCollection<T>(this.entities); }
        }

        #endregion

        #region Methods

        public Repeater<T> AddColumn(string aColumn)
        {
            if (!this.columns.Contains(aColumn))
            {
                this.columns.Add(aColumn);
            }
            return this;
        }

        public Repeater<T> AddEntity(T anEntity)
        {
            if (!this.entities.Contains(anEntity))
            {
                this.entities.Add(anEntity);
            }
            return this;
        }

        public Repeater<T> AddGenerator(string column, Func<T, string> generator)
        {
            if (!this.generators.ContainsKey(column))
            {
                this.generators.Add(column, generator);
            }
            return this;
        }

        public string GenerateHtml()
        {
            IList<string> repeaterHeader = this.GenerateRepeaterHeader();
            IList<string> repeaterBody = this.GenerateRepeaterBody();

            StringBuilder repeaterContent = new StringBuilder();

            if (repeaterHeader.Count > 0)
            {
                TagBuilder header = new TagBuilder(HtmlTags.Div);
                header.MergeAttribute(HtmlAttributes.Name, "header");
                header.InnerHtml = string.Join(string.Empty, repeaterHeader.ToArray());
                repeaterContent.Append(header.ToString());
            }

            if (repeaterBody.Count > 0)
            {
                TagBuilder body = new TagBuilder(HtmlTags.Div);
                body.MergeAttribute(HtmlAttributes.Name, "body");
                body.InnerHtml = string.Join(Environment.NewLine, repeaterBody.ToArray());
                repeaterContent.Append(body.ToString());
            }

            TagBuilder repeater = new TagBuilder(HtmlTags.Div);
            repeater.MergeAttribute(HtmlAttributes.Name, this.Name);
            repeater.InnerHtml = string.Concat(repeaterContent.ToString());

            return repeater.ToString();
        }

        private IList<string> GenerateRepeaterHeader()
        {
            List<string> repeaterHeader = new List<string>();

            if (this.EnableHeader)
            {
                foreach (string aColumn in this.Columns)
                {
                    TagBuilder aTag = new TagBuilder(HtmlTags.Div);
                    aTag.Attributes.Add(HtmlAttributes.Name, aColumn);
                    aTag.SetInnerText(aColumn);

                    repeaterHeader.Add(aTag.ToString());
                }
            }

            return repeaterHeader;
        }

        private IList<string> GenerateRepeaterBody()
        {
            List<string> repeaterBody = new List<string>();

            foreach (var anEntity in this.Entities)
            {
                StringBuilder entityHtml = new StringBuilder();
                foreach (string aProperty in this.Columns)
                {
                    TagBuilder aTag = new TagBuilder(HtmlTags.Div);
                    aTag.Attributes.Add(HtmlAttributes.Name, aProperty);

                    if (this.generators.ContainsKey(aProperty))
                    {
                        aTag.InnerHtml = this.generators[aProperty](anEntity);
                    }
                    else
                    {
                        var fieldValue = ReflectionAssistant.GetPropertyValue(anEntity, aProperty);
                        if (fieldValue != null)
                        {
                            aTag.SetInnerText(fieldValue.ToString());
                        }
                    }
                    entityHtml.Append(aTag.ToString());
                }

                TagBuilder entityTag = new TagBuilder(HtmlTags.Div);
                entityTag.Attributes.Add(HtmlAttributes.Name, "line");
                entityTag.InnerHtml = entityHtml.ToString();

                repeaterBody.Add(entityTag.ToString());
            }

            return repeaterBody;
        }

        #endregion
    }
}