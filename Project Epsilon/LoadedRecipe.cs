using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Epsilon
{
    public static class LoadedRecipe
    {
        public static string file;
        public static List<string> filerows = new List<string>();
        public static bool cavUsed, loginSuccess = false;
        public static string _product, _recipeName, _UDIRecipe,
                         _UDITrayValue, _fieldName, _projectName,
                         _recipeGeneratedBy;

        public static double _pressureUpperAlarmValue, _pressureLowerAlarmValue, _pressureSetpointFromOIT,
                        _tempHigherAlarmValue, _tempLowerAlarmValue, _tempSetpoint,
                        _sealTime, _UDIRecipeTool;

        public static int _RFIDNumber, _recipeNumber, _lotNumber, _avTagRecipeLotSealed, _avTagRecipeLotToSeal,
                    _recToolRequired, _cavMethod2Required, _cavMethodOneSelected,
                    _cavMethodTwoSelected, _cavMgtUsed, recipeID, numCavUsed;

        public static string _tmpUDIRecipe, _recUDI2, _recUDI89, _recUDI1, _recUDI3, _recUDI4, _recUDI5,
                        _recUDI6, _recUDI7, _recUDI8, _recUDI9, _recipeGeneratedOn, fileName, host, port, username, password, headerrow;

        /*public static string Product
        {
            get { return this._product; }
            set { this._product = value; }
        }

        public string RecipeName
        {
            get { return this._recipeName; }
            set { this._recipeName = value; }
        }
        public string ProjectName
        {
            get { return this._projectName; }
            set { this._projectName = value; }
        }
        public string FieldName
        {
            get { return this._fieldName; }
            set { this._fieldName = value; }
        }
        public string RecipeGeneratedBy
        {
            get { return this._recipeGeneratedBy; }
            set { this._recipeGeneratedBy = value; }
        }
        public string RecipeGeneratedOn
        {
            get { return this._recipeGeneratedOn; }
            set { this._recipeGeneratedOn = value; }
        }
        public string TmpUDIRecipe
        {
            get { return this._tmpUDIRecipe; }
            set { this._tmpUDIRecipe = value; }
        }
        public int RecipeNumber
        {
            get { return this._recipeNumber; }
            set { this._recipeNumber = value; }
        }
        public int LotNumber
        {
            get { return this._lotNumber; }
            set { this._lotNumber = value; }
        }
        public int AVTagRecipeLotSealed
        {
            get { return this._avTagRecipeLotSealed; }
            set { this._avTagRecipeLotSealed = value; }
        }
        public int AVTagRecipeLotToSeal
        {
            get { return this._avTagRecipeLotToSeal; }
            set { this._avTagRecipeLotToSeal = value; }
        }
        public int RecToolRequired
        {
            get { return this._recToolRequired; }
            set { this._recToolRequired = value; }
        }
        public int CavMethodOneSelected
        {
            get { return this._cavMethodOneSelected; }
            set { this._cavMethodOneSelected = value; }
        }
        public int CavMethodTwoSelected
        {
            get { return this._cavMethodTwoSelected; }
            set { this._cavMethodTwoSelected = value; }
        }
        public int CavMethod2Required
        {
            get { return this._cavMethod2Required; }
            set { this._cavMethod2Required = value; }
        }
        public int CavMgtUsed
        {
            get { return this._cavMgtUsed; }
            set { this._cavMgtUsed = value; }
        }

        public int UDIRecipeTool
        {
            get { return this._UDIRecipeTool; }
            set { this._UDIRecipeTool = value; }
        }

        public double PressureUpperAlarmValue
        {
            get { return this._pressureUpperAlarmValue; }
            set { this._pressureUpperAlarmValue = value; }
        }
        public double PressureLowerAlarmValue
        {
            get { return this._pressureLowerAlarmValue; }
            set { this._pressureLowerAlarmValue = value; }
        }

        public double PressureSetPointFromOIT
        {
            get { return this._pressureSetpointFromOIT; }
            set { this._pressureSetpointFromOIT = value; }
        }
        public double TempHigherAlarmValue
        {
            get { return this._tempHigherAlarmValue; }
            set { this._tempHigherAlarmValue = value; }
        }
        public double TempLowerAlarmValue
        {
            get { return this._tempLowerAlarmValue; }
            set { this._tempLowerAlarmValue = value; }
        }
        public double TempSetpoint
        {
            get { return this._tempSetpoint; }
            set { this._tempSetpoint = value; }
        }
        public double SealTime
        {
            get { return this._sealTime; }
            set { this._sealTime = value; }
        }

        public int RFIDNumber
        {
            get { return this._RFIDNumber; }
            set { this._RFIDNumber = value; }
        }
        public string UDIRecipe
        {
            get { return this._UDIRecipe; }
            set { this._UDIRecipe = value; }
        }
        public string UDITrayValue
        {
            get { return this._UDITrayValue; }
            set { this._UDITrayValue = value; }
        }

        public string RecUDI1
        {
            get { return this._recUDI1; }
            set { this._recUDI1 = value; }
        }
        public string RecUDI3
        {
            get { return this._recUDI3; }
            set { this._recUDI3 = value; }
        }
        public string RecUDI4
        {
            get { return this._recUDI4; }
            set { this._recUDI4 = value; }
        }
        public string RecUDI5
        {
            get { return this._recUDI5; }
            set { this._recUDI5 = value; }
        }
        public string RecUDI6
        {
            get { return this._recUDI6; }
            set { this._recUDI6 = value; }
        }
        public string RecUDI7
        {
            get { return this._recUDI7; }
            set { this._recUDI7 = value; }
        }
        public string RecUDI8
        {
            get { return this._recUDI8; }
            set { this._recUDI8 = value; }
        }
        public string RecUDI9
        {
            get { return this._recUDI9; }
            set { this._recUDI9 = value; }
        }
        public string RecUDI45
        {
            get { return this._recUDI45; }
            set { this._recUDI45 = value; }
        }
        public string RecUDI89
        {
            get { return this._recUDI89; }
            set { this._recUDI89 = value; }
        }
        */
    }
}
