using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Application.SMSCore.Models;

namespace PTSS.Application.SMSCore.Structure
{
    public class OrganizationStructure
    {
        private string sClassName = "OrganizationStructure";

        public ResponseModel setOrganization()
        {
            string sFunctionName = "setOrganization()";
            
            ResponseModel Response = new ResponseModel();

            try
            {
                OrganizationModel OrganizationModel = new OrganizationModel();
                OrganizationModel.Initialize();
            }
            catch(Exception ex)
            {

            }

            return Response;
        }
    }
}
