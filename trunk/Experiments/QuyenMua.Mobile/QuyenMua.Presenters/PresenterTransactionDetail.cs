using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

using GDNET.Common.MVP;
using GDNET.MvpWeb;

using TVNFramework.Modules.GenericContent.BLL;
using TVNFramework.Modules.Transactions;
using TVNFramework.Modules.Transactions.BLL;
using TVNFramework.Modules.Transactions.Models;
using TVNFramework.InterWeb.Extensions.AccountModels;
using TVNFramework.InterWeb.Extensions.Services;

using TVNFramework.Extensions.MagicNumbers;
using TVNFramework.Extensions.MagicNumbers.Impls;

using QuyenMua.Data.DTOs;
using QuyenMua.Presenters.Views;
using GDNET.Web.Membership.Profiles;

namespace QuyenMua.Presenters
{
    public class PresenterTransactionDetail : PresenterCrudBase<IViewDetailTransaction>
    {
        private GenericTransactionEntity genericTransactionEntity = null;
        private IMembershipService membershipService = null;
        private ItemEntity itemEntity = null;
        private IMagicNumbers magicNumbersGenerator = null;

        private CultureInfo currentCulture = new CultureInfo("vi-VN");
        private const string DefaultPassword = "123456";

        public PresenterTransactionDetail(IViewDetailTransaction view, ViewMode mode)
            : base(view, mode)
        {
            this.membershipService = new AccountMembershipService();
            this.itemEntity = new ItemEntity();
            this.magicNumbersGenerator = new FileStoreMagicNumbers();
        }

        public override bool Create()
        {
            if (base.IsPostBack)
            {
                if (base.CurrentView.Transaction.IsValid())
                {
                    // Create user if possible
                    MembershipUser currentUser = this.membershipService.GetUser(base.CurrentView.Transaction.Email, true);
                    if (currentUser == null)
                    {
                        this.membershipService.CreateUser(base.CurrentView.Transaction.Email, DefaultPassword, base.CurrentView.Transaction.Email, true);
                        currentUser = this.membershipService.GetUser(base.CurrentView.Transaction.Email, true);

                        // Save user profile
                        CustomProfile profile = HttpContext.Current.Profile as CustomProfile;
                        profile.Initialize(currentUser.UserName, true);

                        uint friendlyNumber = this.magicNumbersGenerator.GenerateNumber(MagicNumbersConstants.NumberTypes.MemberFriendlyNumber);
                        profile.BasicInformation.FullName = base.CurrentView.Transaction.FullName;
                        profile.BasicInformation.TelNumber = base.CurrentView.Transaction.Tel;
                        profile.BasicInformation.FriendlyNumber = friendlyNumber.ToString();

                        profile.Save();
                    }

                    GenericTransactionModel model = new GenericTransactionModel
                    {
                        Amount = base.CurrentView.Transaction.Amount,
                        Price = base.CurrentView.Transaction.Price,
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = DateTime.Now,
                        CreatedBy = (Guid)currentUser.ProviderUserKey,
                    };

                    model.ManagedBy = this.itemEntity.GetItemModelByName(base.CurrentView.Transaction.SecuritiesCorp, false).Id;
                    model.SymbolId = this.itemEntity.GetItemModelByName(base.CurrentView.Transaction.Symbol, false).Id;
                    model.PlaceId = this.itemEntity.GetItemModelByName(base.CurrentView.Transaction.Place, false).Id;

                    int results = this.genericTransactionEntity.CreateOrUpdate(model);
                    if (results > 0)
                    {
                    }
                }
                else
                {
                    base.CurrentView.Notifier.Message = "Invalid input data, please try again.";
                    base.CurrentView.Transaction = base.CurrentView.Transaction;
                }
            }

            return false;
        }
    }
}
