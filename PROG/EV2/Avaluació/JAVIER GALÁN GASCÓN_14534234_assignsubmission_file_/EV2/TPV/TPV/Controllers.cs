using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVLib
{
    public class Controllers
    {
        public static void RunMainMenu(ITPV tpv)
        {
            //ViewTPV v = new viewTPV();
            //bool IsRunning = true;
            //while (IsRunning)
            //{
            //    ViewTPV.ShowMainMenu(tpv);
            //    var option = ViewTPV.Read(tpv);

            //}

            bool IsRunning = true;
            while (IsRunning)
            {

                string? option = UI.ShowMainMenu();
                //if (option != null)
                //{
                    switch (option)
                    {
                        case "1":
                            {
                                UI.CaseGetProduct(tpv);
                                break;
                            }
                        case "2":
                            {
                                UI.CaseGetProducts(tpv);
                                break;
                            }
                        case "3":
                            {
                                UI.CaseAddProduct(tpv);
                                break;
                            }
                        case "4":
                            {
                                UI.CaseUpdateProduct(tpv);
                                break;
                            }
                        case "5":
                            {
                                UI.CaseRemoveProduct(tpv);
                                break;
                            }
                        case "6":
                            {
                                UI.CaseExit(tpv, out IsRunning);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                //}
            }
            //public static void RunMainMenu(ITPV tpv)
            //{
            //    
            //    }
            //}
        }

        public static void Start(ITPV tpv)
        {
            RunMainMenu(tpv);
        }

    }
}
