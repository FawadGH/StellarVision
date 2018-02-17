using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Application.SMSCore.DataAccess;
using PTSS.Logger;
using System.Data;

namespace PTSS.Application.SMSCore.Models
{
    public class OrganizationModel
    {
        private string sClassName = "OrganizationModel";
        public string Name;
        public string Mnemonic;
        public string ProdutionYear;
        public string LicenseA;
        public string LicenseB;
        public string LicenseHash;
        public int TotalBranches;
        SMSCoreData Data = new SMSCoreData();
        Logger.Logger oLog = new Logger.Logger();
        public void Initialize()
        {
            string sFunctionName = "Initialize()";
            DataView oDV = new DataView();
            try
            {
                Data.getOrganizationDetails(out oDV);
                foreach (DataRowView row in oDV)
                {
                    this.Name = row["Name"].ToString();
                    this.Mnemonic = row["Organization_Mnemonic"].ToString();
                    this.ProdutionYear = row["Production_Year"].ToString();
                    this.LicenseA = row["LicenseA"].ToString();
                    this.LicenseB = row["LicenseB"].ToString();
                }
                Data.getTotalBranches(out oDV);
                foreach (DataRowView row in oDV)
                {
                    this.TotalBranches = Convert.ToInt32(row[0].ToString());
                }
            }
            catch(Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.ToString());
                #endregion Text Logging
            }
        }
        public bool setLicenseHash()
        {
            bool LicenseHashSet = false;

            this.LicenseHash = this.LicenseA.Replace("-", "") + this.LicenseB.Replace("-", "");
            LicenseHashSet = true;

            return LicenseHashSet;
        }
    }
}
