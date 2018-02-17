using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Application.SMSCore.Models;
using PTSS.Logger;

namespace PTSS.Application.SMSCore.Structure
{
    public class LicenseStructure
    {
        private string sClassName = "LicenseStructure";
        Logger.Logger oLog = new Logger.Logger();
        public OrganizationModel OrganizationModel;
        public ResponseModel setLicenseVariables(out LicenseModel License)
        {
            string sFunctionName = "setLicenseVariables()";
            ResponseModel Response = new ResponseModel();
            //LicenseModel License = new LicenseModel();
            License = new LicenseModel();
            try
            {
                License.OrganizationName = OrganizationModel.Name;
                License.OrganizationMnemonic = OrganizationModel.Mnemonic;
                License.ProductionYear = OrganizationModel.ProdutionYear;
                License.TotalBranches = OrganizationModel.TotalBranches;
                Response.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging
                Response.FailedWithException();
            }

            return Response;
        }
    }
}
