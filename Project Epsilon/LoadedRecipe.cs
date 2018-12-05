using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Epsilon
{
    public static class LoadedRecipe
    {
        // Initialize each of the properties for a LoadedRecipe object
        public static string file;
        public static List<string> filerows = new List<string>();
        public static bool cavUsed, loginSuccess = false, recipeloaded = false, confirmload = false;


        public static string _product, _recipeName, _UDIRecipe,
                         _UDITrayValue, _fieldName, _projectName,
                         _recipeGeneratedBy;


        public static double _pressureUpperAlarmValue, _pressureLowerAlarmValue, _pressureSetpointFromOIT,
                        _tempHigherAlarmValue, _tempLowerAlarmValue, _tempSetpoint,
                        _sealTime, _UDIRecipeTool;

        public static int _RFIDNumber, _recipeNumber, _lotNumber, _avTagRecipeLotSealed, _avTagRecipeLotToSeal,
                    _recToolRequired, _cavMethod2Required, _cavMethodOneSelected,
                    _cavMethodTwoSelected, _cavMgtUsed, recipeID, numCavUsed, _recUDI1;


        public static string _tmpUDIRecipe, _recUDI2, _recUDI89, _recUDI3, _recUDI4, _recUDI5,
                        _recUDI6, _recUDI7, _recUDI8, _recUDI9, _recipeGeneratedOn, fileName, host, port, username, password, headerrow;

        public static void ClearData()
        {
            // Clear/reset each property of LoadedRecipe object
            LoadedRecipe.recipeloaded = false;

            LoadedRecipe._product = "";
            LoadedRecipe._recipeName = "";
            LoadedRecipe._UDIRecipe = "";
            LoadedRecipe._UDITrayValue = "";
            LoadedRecipe._fieldName = "";
            LoadedRecipe._projectName = "";
            LoadedRecipe._recipeGeneratedBy = "";

            LoadedRecipe._pressureUpperAlarmValue = 0.0;
            LoadedRecipe._pressureLowerAlarmValue = 0.0;
            LoadedRecipe._pressureSetpointFromOIT = 0.0;
            LoadedRecipe._tempHigherAlarmValue = 0.0;
            LoadedRecipe._tempLowerAlarmValue = 0.0;
            LoadedRecipe._tempSetpoint = 0.0;
            LoadedRecipe._sealTime = 0.0;
            LoadedRecipe._UDIRecipeTool = 0.0;

            LoadedRecipe._RFIDNumber = 0;
            LoadedRecipe._recipeNumber = 0;
            LoadedRecipe._lotNumber = 0;
            LoadedRecipe._avTagRecipeLotSealed = 0;
            LoadedRecipe._avTagRecipeLotToSeal = 0;
            LoadedRecipe._recToolRequired = 0;
            LoadedRecipe._cavMethod2Required = 0;
            LoadedRecipe._cavMethodOneSelected = 0;
            LoadedRecipe._cavMethodTwoSelected = 0;
            LoadedRecipe._cavMgtUsed = 0;
            LoadedRecipe.recipeID = 0;
            LoadedRecipe.numCavUsed = 0;

            LoadedRecipe._tmpUDIRecipe = "";
            LoadedRecipe._recUDI2 = "";
            LoadedRecipe._recUDI89 = "";
            LoadedRecipe._recUDI1 = 0;
            LoadedRecipe._recUDI3 = "";
            LoadedRecipe._recUDI4 = "";
            LoadedRecipe._recUDI5 = "";
            LoadedRecipe._recUDI6 = "";
            LoadedRecipe._recUDI7 = "";
            LoadedRecipe._recUDI8 = "";
            LoadedRecipe._recipeGeneratedOn = "";
            LoadedRecipe.fileName = "";
            LoadedRecipe.host = "";
            LoadedRecipe.port = "";
            LoadedRecipe.username = "";
            LoadedRecipe.password = "";
            LoadedRecipe.headerrow = "";
        }


    }
    
}
