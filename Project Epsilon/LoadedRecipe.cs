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
        public static bool cavUsed, loginSuccess = false, recipeloaded = false;


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

        
        
    }
}
