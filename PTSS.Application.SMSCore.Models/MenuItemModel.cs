using PTSS.Application.SMSCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.Models
{
    public class MenuItemModel
    {
        private string sClassName = "MenuItemModel";
        private SMSCoreData Data = new SMSCoreData();

        #region ColumnNames
        private const string cModuleID = "ModuleID";
        private const string cModuleName = "ModuleName";
        private const string cLicenseA = "LicenseA";
        private const string cLicenseB = "LicenseB";
        private const string cIsModuleActive = "isActive";
        private const string cModuleController = "ModuleController";
        private const string cModuleAction = "ModuleAction";
        private const string cModuleIcon = "ModuleIcon";
        private const string cModuleIconClass = "ModuleIconClass";
        private const string cModuleDisplayOrder = "DisplayOrder";
        private const string cModuleDescription = "ModuleDescription";
        private const string cModuleHasChild = "hasChild";
        private const string cModuleFunctionID = "ModuleFunctionID";
        private const string cModuleFunctionName = "ModuleFunctionName";
        private const string cIsModuleFunctionActive = "isActive";
        private const string cModuleFunctionController = "ModuleFunctionController";
        private const string cModuleFunctionAction = "ModuleFunctionAction";
        private const string cModuleFunctionIcon = "ModuleFunctionIcon";
        private const string cModuleFunctionIconClass = "ModuleFunctionIconClass";
        private const string cModuleFunctionDisplayOrder = "DisplayOrder";
        private const string cModuleFunctionDescription = "ModuleFunctionDescription";
        #endregion ColumnNames

        #region Menu Attributes

        #endregion Menu Attributes

        #region GetNSet
        public string ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string LicenseA { get; set; }
        public string LicenseB { get; set; }
        public bool isModuleActive { get; set; }
        public string ModuleController { get; set; }
        public string ModuleAction { get; set; }
        public string ModuleIconURL { get; set; }
        public string ModuleIconClass { get; set; }
        public string ModuleDisplayOrder { get; set; }
        public string ModuleDescription { get; set; }
        public string ModuleFunctionID { get; set; }
        public string ModuleFunctionName { get; set; }
        public bool isModuleFunctionActive { get; set; }
        public string ModuleFunctionController { get; set; }
        public string ModuleFunctionAction { get; set; }
        public string ModuleFunctionIconURL { get; set; }
        public string ModuleFunctionIconClass { get; set; }
        public string ModuleFunctionDisplayOrder { get; set; }
        public string ModuleFunctionDescription { get; set; }
        public bool hasChildItem { get; set; }
        public bool isSelected { get; set; }
        public List<MenuItemModel> ModulesList { get; set; }
        private List<MenuItemModel> moduleFunctionsList = new List<MenuItemModel>();
        public List<MenuItemModel> ModuleFunctionsList
        {
            get
            {
                return moduleFunctionsList;
            }
            set
            {
                moduleFunctionsList = value;
            }
        }
        #endregion GetNSet

        public ResponseModel getMainMenuItem(string ModuleID, string ModuleFunctionID)
        {
            string sFunctionName = "getMainMenuItem(,)";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            try
            {
                Data.getModuleByModuleID(ModuleID, out oDV);
                foreach(DataRowView row in oDV)
                {
                    this.ModuleID = row[cModuleID].ToString();
                    ModuleName = row[cModuleName].ToString();
                    LicenseA = row[cLicenseA].ToString();
                    LicenseB = row[cLicenseB].ToString();
                    isModuleActive = row[cIsModuleActive].ToString() == "1" ? true : false;
                    ModuleController = row[cModuleController].ToString();
                    ModuleAction = row[cModuleAction].ToString();
                    ModuleIconURL = row[cModuleIcon].ToString();
                    ModuleIconClass = row[cModuleIconClass].ToString();
                    ModuleDisplayOrder = row[cModuleDisplayOrder].ToString();
                    ModuleDescription = row[cModuleDescription].ToString();
                    hasChildItem = ModuleFunctionID == null || ModuleFunctionID == "" ? false : true;
                }
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {

                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel getChildMenuItem(string ModuleID, string ModuleFunctionID)
        {
            string sFunctionName = "getChildMenuItem(,)";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            try
            {
                Data.getModuleFunction(ModuleID, ModuleFunctionID, out oDV);
                foreach(DataRowView row in oDV)
                {
                    this.ModuleID = row[cModuleID].ToString();
                    this.ModuleFunctionID = row[cModuleFunctionID].ToString();
                    ModuleFunctionName = row[cModuleFunctionName].ToString();
                    isModuleFunctionActive = row[cIsModuleFunctionActive].ToString() == "1" ? true : false;
                    ModuleFunctionController = row[cModuleFunctionController].ToString();
                    ModuleFunctionAction = row[cModuleFunctionAction].ToString();
                    ModuleFunctionIconURL = row[cModuleFunctionIcon].ToString();
                    ModuleFunctionIconClass = row[cModuleFunctionIconClass].ToString();
                    ModuleFunctionDisplayOrder = row[cModuleFunctionDisplayOrder].ToString();
                    ModuleFunctionDescription = row[cModuleFunctionDescription].ToString();
                }
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {

                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel getAllModules()
        {
            string sFunctionName = "getAllModules()";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            ModulesList = new List<MenuItemModel>();
            MenuItemModel Item;
            try
            {
                Data.getAllModules(out oDV);
                foreach (DataRowView row in oDV)
                {
                    Item = new MenuItemModel();
                    Item.ModuleID = row[cModuleID].ToString();
                    Item.ModuleName = row[cModuleName].ToString();
                    Item.LicenseA = row[cLicenseA].ToString();
                    Item.LicenseB = row[cLicenseB].ToString();
                    Item.isModuleActive = row[cIsModuleActive].ToString() == "1" ? true : false;
                    Item.ModuleController = row[cModuleController].ToString();
                    Item.ModuleAction = row[cModuleAction].ToString();
                    Item.ModuleIconURL = row[cModuleIcon].ToString();
                    Item.ModuleIconClass = row[cModuleIconClass].ToString();
                    Item.ModuleDisplayOrder = row[cModuleDisplayOrder].ToString();
                    Item.ModuleDescription = row[cModuleDescription].ToString();
                    Item.hasChildItem = row[cModuleHasChild].ToString() == "1" ? true : false;
                    ModulesList.Add(Item);
                }
                Result.SuccessfullyPassed();
            }
            catch (Exception ex)
            {

                Result.FailedWithException();
            }
            return Result;
        }

        public ResponseModel getAllModuleFunctions(ref List<MenuItemModel> ModulesList)
        {
            string sFunctionName = "getAllModuleFunctions()";
            ResponseModel Result = new ResponseModel();
            DataView oDV = new DataView();
            MenuItemModel Item;
            //ModuleFunctionsList = new List<MenuItemModel>();
            try
            {
                Data.getAllModuleFunctions(out oDV);
                foreach (DataRowView row in oDV)
                {
                    Item = new MenuItemModel();
                    Item.ModuleID = row[cModuleID].ToString();
                    Item.ModuleFunctionID = row[cModuleFunctionID].ToString();
                    Item.ModuleFunctionName = row[cModuleFunctionName].ToString();
                    Item.isModuleFunctionActive = row[cIsModuleFunctionActive].ToString() == "1" ? true : false;
                    Item.ModuleFunctionController = row[cModuleFunctionController].ToString();
                    Item.ModuleFunctionAction = row[cModuleFunctionAction].ToString();
                    Item.ModuleFunctionIconURL = row[cModuleFunctionIcon].ToString();
                    Item.ModuleFunctionIconClass = row[cModuleFunctionIconClass].ToString();
                    Item.ModuleFunctionDisplayOrder = row[cModuleFunctionDisplayOrder].ToString();
                    Item.ModuleFunctionDescription = row[cModuleFunctionDescription].ToString();
                    foreach(MenuItemModel Module in ModulesList)
                    {
                        if(Module.ModuleID == Item.ModuleID)
                        {
                            Module.ModuleFunctionsList.Add(Item);
                        }
                    }
                    //ModuleFunctionsList.Add(Item);
                }
                Result.SuccessfullyPassed();
            }
            catch (Exception ex)
            {

                Result.FailedWithException();
            }
            return Result;
        }
    }
}
