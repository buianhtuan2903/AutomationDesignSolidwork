using System;

using SolidWorks.Interop.sldworks;
using Microsoft.Office.Interop.Excel;


namespace DieSetTool
{
    class SType
    {
        public double x_clamp;
        public double A;
        public double S;
        public double B;
        public double U;
        public double C;
        public string DataLocation;
        public string SaveLocation;
        public double Molddim;
        public void getdata(String combobox1data, String combobox2data, String combobox3data, String combobox4data, String combobox5data, String combobox6data, String combobox7data, String TB2data, String TB3data)
        {
            MainWindow run = new MainWindow();
            Molddim = (Convert.ToDouble(combobox1data));
            x_clamp = (Convert.ToDouble(combobox2data)) / 1000;
            A = (Convert.ToDouble(combobox3data)) / 1000;
            S = (Convert.ToDouble(combobox4data)) / 1000;
            B = (Convert.ToDouble(combobox5data)) / 1000;
            U = (Convert.ToDouble(combobox6data)) / 1000;
            C = (Convert.ToDouble(combobox7data)) / 1000;
            
            DataLocation = TB2data;
            SaveLocation = TB3data;
        }
        public void STypeCode()
        {
            // 3 Plate mold base DE type
            SldWorks swApp = new SldWorks(); ;
            swApp.Visible = true;
            ModelDoc2 swDoc = null;
            AssemblyDoc swAssembly = null;

            bool boolstatus = false;
            int longstatus = 0;
            int longwarnings = 0;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;

            xlApp.Workbooks.Open(DataLocation);

            Workbook xlWB = xlApp.ActiveWorkbook;
            Worksheet xlWS = xlApp.ActiveSheet;

            double x_mold = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 2, false)) / 1000;
            double y_mold = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 3, false)) / 1000;

            double T = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 5, false)) / 1000;
           
            double E = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 6, false)) / 1000;
            double F = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 7, false)) / 1000;
            double x_EF = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 8, false)) / 1000;
            double x_C = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 9, false)) / 1000;
            double L = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 10, false)) / 1000;

            double x_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"].Value2, 11, false)) / 2000;
            double y_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 12, false)) / 2000;
            double y1_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 13, false)) / 1000;
            double d_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 14, false)) / 1000;
            double head_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 15, false)) / 1000;
            double hhead_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 16, false)) / 1000;

            double d1_GB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 17, false)) / 1000;
            double head_GB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 18, false)) / 1000;
            double hhead_GB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 19, false)) / 1000;

            double x_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 20, false)) / 2000;
            double y_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 21, false)) / 2000;
            double d_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 22, false)) / 1000;
            double head_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 23, false)) / 1000;
            double hhead_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 24, false)) / 1000;

            double spacer = 0.005;

            double x_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 25, false)) / 2000;
            double y_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 26, false)) / 2000;
            double m_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 27, false));
            double head_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 2, false)) / 1000;
            double hhead_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 3, false)) / 1000;
            double headhole_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 4, false)) / 1000;
            double hheadhole_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 5, false)) / 1000;
            double d1_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 6, false)) / 1000;
            double d2_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 7, false)) / 1000;
            double l_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A105:H115"], 8, false)) / 1000;

            double x_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 28, false)) / 2000;
            double y_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 29, false)) / 2000;
            double l1_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 31, false)) / 1000;
            double m_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 30, false));
            double head_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A105:H115"], 2, false)) / 1000;
            double hhead_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A105:H115"], 3, false)) / 1000;
            double headhole_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A105:H115"], 4, false)) / 1000;
            double hheadhole_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A105:H115"], 5, false)) / 1000;
            double d1_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A105:H115"], 6, false)) / 1000;

            double y_TB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ94"], 33, false)) / 2000;

            Feature swHoleFeature;
            Feature swSketchFeature;

            xlWB.Close(false, null, null);
            xlApp.Quit();

            // --------------------------------------------------------------
            // New Assembly
            ModelDoc2 Part = swDoc;
            swAssembly = swApp.NewAssembly();
            
            swApp.ActivateDoc2("Assem1", false, 0);
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));
            // -------------------------------------
            // Insert Cavity Clamping Plate
            object Plane1 = null;
            Component2 swComponent1;

            longstatus = swAssembly.InsertNewVirtualPart(Plane1, out swComponent1);
            boolstatus = swDoc.Extension.SelectByID2("Part1^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part1^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);

            swApp.ActivateDoc2("Part1^Assem1.sldprt", false, ref longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);

            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch1 = null;
            Sketch1 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_clamp / 2, y_mold / 2, 0)));
            Feature Extrude1 = null;
            Extrude1 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, T, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            if (T > 0.026)
            {
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                Array SketchCut10 = null;
                SketchCut10 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(-x_clamp / 2, -y_mold / 2, 0, -x_mold / 2, y_mold / 2, 0)));
                SketchCut10 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(x_clamp / 2, -y_mold / 2, 0, x_mold / 2, y_mold / 2, 0)));

                Feature Cut10 = null;
                Cut10 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, T - 0.025, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -T, false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
            }

            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_CB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_CB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, y_CB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_CB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_TB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_TB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(x_CB, y_TB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_TB, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);

                }
                else
                {
                    boolstatus = swDoc.Extension.SelectByRay(x_CB, 0, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);

                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, 0, 0, 0, 0, -1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
            }

            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Cavity Clamping Plate.sldprt");

            // Close Document
            swDoc = null;
            swApp.CloseDoc("Cavity Clamping Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // ----------------------------------------
            // Insert Cavity Plate
            object Plane3 = null;
            Component2 swComponent3;

            longstatus = swAssembly.InsertNewVirtualPart(Plane3, out swComponent3);
            boolstatus = swDoc.Extension.SelectByID2("Part2^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part2^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part2^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch3;
            Sketch3 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
            Feature Extrude3 = null;
            Extrude3 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, A, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole GBA
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut30 = null;

            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - d1_GB / 2, y_GP, 0)));
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - d1_GB / 2, -y_GP, 0)));
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - d1_GB / 2, y_GP, 0)));

            Feature Cut30 = null;
            Cut30 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, A, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Head GBA for Guide pin
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut31 = null;
            SketchCut31 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - head_GB / 2 - 0.0005, y_GP, 0)));
            SketchCut31 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - head_GB / 2 - 0.0005, -y_GP, 0)));
            SketchCut31 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - head_GB / 2 - 0.0005, y_GP, 0)));

            Feature Cut31 = null;
            Cut31 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, hhead_GB, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

           
            // Create special hole


            boolstatus = swDoc.Extension.SelectByRay(x_GP, -y1_GP, -(T ), x_GP, -y1_GP, -(T + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_GB, A, -1, head_GB + 0.001, hhead_GB, 0, 1, 2.05948851735331, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_CB, -(T + A ), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_CB, -(T + A  ), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, y_CB, -(T + A ), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_CB, -(T + A ), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_TB, -(T + A), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_TB, -(T + A), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(x_CB, y_TB, -(T + A), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_TB, -(T + A), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
                else
                {
                    boolstatus = swDoc.Extension.SelectByRay(x_CB, 0, -(T + A), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                    
                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, 0, -(T + A), 0, 0, -(T + A + 1), 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
            }

            // Save
         
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Cavity Plate.sldprt");

            // Close Document
            swDoc = null;
            swApp.CloseDoc("Cavity Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // ---------------------------------------------
            // Insert Stripper Plate
            object Plane4 = null;
            Component2 swComponent4;
            longstatus = swAssembly.InsertNewVirtualPart(Plane4, out swComponent4);
            boolstatus = swDoc.Extension.SelectByID2("Part3^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part3^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part3^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            if (S != 0)
            {
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);


                // Create Sketch - Extrude
                Array Sketch4;
                Sketch4 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
                Feature Extrude4 = null;
                Extrude4 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, S, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A), false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);

                // Create Hole GBB Guide Pin
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                SketchSegment SketchCut40 = null;
                SketchCut40 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - d1_GB / 2, y_GP, 0)));
                SketchCut40 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - d1_GB / 2, -y_GP, 0)));
                SketchCut40 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - d1_GB / 2, y_GP, 0)));

                Feature Cut40 = null;
                Cut40 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, S, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
                
                // Create special hole


                boolstatus = swDoc.Extension.SelectByRay(x_GP, -y1_GP, -(T + A), x_GP, -y1_GP, -(T + A + 1), 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(2, 8, 143, "Ø0.15", 1, d1_GB, S, -1, 1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);


            }
            // Save
            
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Stripper Plate.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("Stripper Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // ---------------------------------------------
            // Insert CorePlate
            object Plane5 = null;
            Component2 swComponent5;
            longstatus = swAssembly.InsertNewVirtualPart(Plane5, out swComponent5);
            boolstatus = swDoc.Extension.SelectByID2("Part4^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part4^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part4^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch  - Extrude
            Array Sketch5;
            Sketch5 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
            Feature Extrude5 = null;
            Extrude5 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, B, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Hole SPP + GP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut50 = null;

            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - d_GP / 2, y_GP, 0)));
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - d_GP / 2, -y_GP, 0)));
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - d_GP / 2, y_GP, 0)));

            Feature Cut50 = null;
            Cut50 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, B, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Head GP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut52 = null;


            SketchCut52 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - head_GP / 2 - 0.0005, y_GP, 0)));
            SketchCut52 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - head_GP / 2 - 0.0005, -y_GP, 0)));
            SketchCut52 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - head_GP / 2 - 0.0005, y_GP, 0)));


            Feature Cut52 = null;
            Cut52 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, hhead_GP, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create special hole

            boolstatus = swDoc.Extension.SelectByRay(x_GP, -y1_GP, -(T + A + S + B), x_GP, -y1_GP, -(T + A + S + B - 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d_GP, B, -1, head_GP + 0.001, hhead_GP, 0, 1, 2.05948851735331, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            // Create Hole Return Pin
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut53 = null;
            SketchCut53 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, y_RP, 0, -x_RP - d_RP / 2, y_RP, 0)));
            SketchCut53 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, -y_RP, 0, -x_RP - d_RP / 2, -y_RP, 0)));
            SketchCut53 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, y_RP, 0, x_RP - d_RP / 2, y_RP, 0)));
            SketchCut53 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, -y_RP, 0, x_RP - d_RP / 2, -y_RP, 0)));


            Feature Cut53 = null;
            Cut53 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, B, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_CB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_CB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, y_CB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_CB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_TB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_TB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(x_CB, y_TB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_TB, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
                else
                {
                    boolstatus = swDoc.Extension.SelectByRay(x_CB, 0, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, 0, -(T + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
            }


            // Save
            
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Core Plate.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("Core Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // ------------------------------------------------------
            // Insert BackPlate
            object Plane6 = null;
            Component2 swComponent6;
            longstatus = swAssembly.InsertNewVirtualPart(Plane6, out swComponent6);
            boolstatus = swDoc.Extension.SelectByID2("Part5^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part5^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part5^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            if (U != 0)
            {
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);

                // Create Sketch  - Extrude
                Array Sketch6;
                Sketch6 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
                Feature Extrude6 = null;
                Extrude6 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, U, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B), false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
                
                // Create Hole Return Pin
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                SketchSegment SketchCut61 = null;
                SketchCut61 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, y_RP, 0, -x_RP - d_RP / 2 - 0.0005, y_RP, 0)));
                SketchCut61 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, -y_RP, 0, -x_RP - d_RP / 2 - 0.0005, -y_RP, 0)));
                SketchCut61 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, y_RP, 0, x_RP - d_RP / 2 - 0.0005, y_RP, 0)));
                SketchCut61 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, -y_RP, 0, x_RP - d_RP / 2 - 0.0005, -y_RP, 0)));

                Feature Cut61 = null;
                Cut61 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, U, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);


                // Create hole counterbore
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                SketchSegment SketchCut62 = null;
                SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, y_CB, 0, -x_CB - d1_CB / 2, y_CB, 0)));
                SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, -y_CB, 0, -x_CB - d1_CB / 2, -y_CB, 0)));
                SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, y_CB, 0, x_CB - d1_CB / 2, y_CB, 0)));
                SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, -y_CB, 0, x_CB - d1_CB / 2, -y_CB, 0)));
                if (y_CB * 2000 > 179)
                {
                    if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                    {
                        SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, y_TB, 0, -x_CB - d1_CB / 2, y_TB, 0)));
                        SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, -y_TB, 0, -x_CB - d1_CB / 2, -y_TB, 0)));
                        SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, y_TB, 0, x_CB - d1_CB / 2, y_TB, 0)));
                        SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, -y_TB, 0, x_CB - d1_CB / 2, -y_TB, 0)));
                    }
                    else
                    {
                        SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, 0, 0, -x_CB - d1_CB / 2, 0, 0)));
                        SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, 0, 0, x_CB - d1_CB / 2, 0, 0)));
                    }
                }
                Feature Cut62 = null;
                Cut62 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, U, 0, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);


            }
            // Save
            
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Back Plate.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("Back Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // ------------------------------------------------------
            // Insert Opposite Spacer Block
            object Plane7 = null;
            Component2 swComponent7;
            longstatus = swAssembly.InsertNewVirtualPart(Plane7, out swComponent7);
            boolstatus = swDoc.Extension.SelectByID2("Part6^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part6^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part6^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch7;
            Sketch7 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(x_mold / 2, -y_mold / 2, 0, x_mold / 2 - x_C, y_mold / 2, 0)));
            Feature Extrude7 = null;
            Extrude7 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole Counter Bolt
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut71 = null;
            SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, y_CB, 0, x_CB - d1_CB / 2, y_CB, 0)));
            SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, -y_CB, 0, x_CB - d1_CB / 2, -y_CB, 0)));

            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, y_TB, 0, x_CB - d1_CB / 2, y_TB, 0)));
                    SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, -y_TB, 0, x_CB - d1_CB / 2, -y_TB, 0)));
                }
                else
                {
                    SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, 0, 0, x_CB - d1_CB / 2, 0, 0)));
                }
               
            }


            Feature Cut71 = null;
            Cut71 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Save
            
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Opposite Spacer Block.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("Opposite Spacer Block.sldprt");
            swDoc = swApp.ActiveDoc;

            // -----------------------------------------------------
            // Insert Spacer Block
            object Plane8 = null;
            Component2 swComponent8;
            longstatus = swAssembly.InsertNewVirtualPart(Plane8, out swComponent8);
            boolstatus = swDoc.Extension.SelectByID2("Part7^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part7^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part7^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch8;
            Sketch8 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(-x_mold / 2, y_mold / 2, 0, -x_mold / 2 + x_C, -y_mold / 2, 0)));
            Feature Extrude8 = null;
            Extrude8 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole Counter Bolt
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut81 = null;
            SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, y_CB, 0, -x_CB - d1_CB / 2, y_CB, 0)));
            SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, -y_CB, 0, -x_CB - d1_CB / 2, -y_CB, 0)));

            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, y_TB, 0, -x_CB - d1_CB / 2, y_TB, 0)));
                    SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, -y_TB, 0, -x_CB - d1_CB / 2, -y_TB, 0)));
                }
                else
                {
                    SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, 0, 0, -x_CB - d1_CB / 2, 0, 0)));
                }
            }
            
            Feature Cut81 = null;
            Cut81 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Spacer Block.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("Spacer Block.sldprt");
            swDoc = swApp.ActiveDoc;

            // ---------------------------------------------------------
            // Insert Ejector Upper
            object Plane9 = null;
            Component2 swComponent9;
            longstatus = swAssembly.InsertNewVirtualPart(Plane9, out swComponent9);
            boolstatus = swDoc.Extension.SelectByID2("Part8^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part8^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part8^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch9;
            Sketch9 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_EF / 2, y_mold / 2, 0)));
            Feature Extrude9 = null;
            Extrude9 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, E, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C - spacer - E - F), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole Return Pin
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut90 = null;
            SketchCut90 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, y_RP, 0, -x_RP - d_RP / 2 - 0.0001, y_RP, 0)));
            SketchCut90 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, -y_RP, 0, -x_RP - d_RP / 2 - 0.0001, -y_RP, 0)));
            SketchCut90 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, y_RP, 0, x_RP - d_RP / 2 - 0.0001, y_RP, 0)));
            SketchCut90 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, -y_RP, 0, x_RP - d_RP / 2 - 0.0001, -y_RP, 0)));


            Feature Cut90 = null;
            Cut90 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, E, 0, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U + C - spacer - E - F), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Head Return Pin
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut91 = null;
            SketchCut91 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, y_RP, 0, -x_RP - head_RP / 2 - 0.0005, y_RP, 0)));
            SketchCut91 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_RP, -y_RP, 0, -x_RP - head_RP / 2 - 0.0005, -y_RP, 0)));
            SketchCut91 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, y_RP, 0, x_RP - head_RP / 2 - 0.0005, y_RP, 0)));
            SketchCut91 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_RP, -y_RP, 0, x_RP - head_RP / 2 - 0.0005, -y_RP, 0)));

            Feature Cut91 = null;
            Cut91 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, hhead_RP, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U + C - spacer - F), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Hole Ejector Bolt
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut92 = null;
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_EB, y_EB, 0, -x_EB - m_EB / 2000, y_EB, 0)));

            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_EB, -y_EB, 0, x_EB - m_EB / 2000, -y_EB, 0)));
            
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_EB, y_EB, 0, x_EB - (m_EB / 2000), y_EB, 0)));
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_EB, -y_EB, 0, (-x_EB) - (m_EB / 2000), -y_EB, 0)));

            Feature Cut92 = null;
            Cut92 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, E, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U + C - spacer - E - F), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            if (Molddim > 5554)
            {
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                SketchSegment SketchCut93 = null;
                SketchCut93 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_EB, 0, 0, -x_EB - m_EB / 2000, 0, 0)));
                SketchCut93 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_EB, 0, 0, x_EB - m_EB / 2000, 0, 0)));
                
                Feature Cut93 = null;
                Cut93 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, E, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U + C - spacer - E - F), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
            }

            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Ejector Upper.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("Ejector Upper.sldprt");
            swDoc = swApp.ActiveDoc;

            // -------------------------------------------------------
            // Insert Ejector Lower
            object Plane10 = null;
            Component2 swComponent10;
            longstatus = swAssembly.InsertNewVirtualPart(Plane10, out swComponent10);
            boolstatus = swDoc.Extension.SelectByID2("Part9^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part9^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part9^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch10;
            Sketch10 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_EF / 2, y_mold / 2, 0)));
            Feature Extrude10 = null;
            Extrude10 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, F, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C - spacer - F), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_EB, y_EB, -(T + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);
            
            boolstatus = swDoc.Extension.SelectByRay(-x_EB, -y_EB, -(T + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);
            
            boolstatus = swDoc.Extension.SelectByRay(x_EB, y_EB, -(T + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);
            
            boolstatus = swDoc.Extension.SelectByRay(x_EB, -y_EB, -(T + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            if (Molddim > 5554)
            {
                boolstatus = swDoc.Extension.SelectByRay(x_EB, 0, -(T + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);

                boolstatus = swDoc.Extension.SelectByRay(-x_EB, 0, -(T + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);

            }
            // Save
       
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Ejector Lower.sldprt");
            // Close Document

            swDoc = null;
            swApp.CloseDoc("Ejector Lower.sldprt");
            swDoc = swApp.ActiveDoc;

            // ---------------------------------------------------
            // Insert Core Clamping Plate
            object Plane11 = null;
            Component2 swComponent11;
            longstatus = swAssembly.InsertNewVirtualPart(Plane11, out swComponent11);
            boolstatus = swDoc.Extension.SelectByID2("Part10^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part10^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part10^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);


            // Create Sketch - Extrude
            Array Sketch11;
            Sketch11 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(-x_clamp / 2, -y_mold / 2, 0, x_clamp / 2, y_mold / 2, 0)));
            Feature Extrude11 = null;
            Extrude11 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, L, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            if (L > 0.026)
            {
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                Array SketchCut110 = null;
                SketchCut110 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(-x_clamp / 2, -y_mold / 2, 0, -x_mold / 2, y_mold / 2, 0)));
                SketchCut110 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(x_clamp / 2, -y_mold / 2, 0, x_mold / 2, y_mold / 2, 0)));

                Feature Cut110 = null;
                Cut110 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, L - 0.025, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U + C), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
            }

            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_CB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_CB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, y_CB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_CB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_TB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);

                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_TB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);

                    boolstatus = swDoc.Extension.SelectByRay(x_CB, y_TB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);

                    boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_TB, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
                else
                {
                    boolstatus = swDoc.Extension.SelectByRay(x_CB, 0, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);


                    boolstatus = swDoc.Extension.SelectByRay(-x_CB, 0, -(T + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                    swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                    swSketchFeature = swHoleFeature.GetFirstSubFeature();
                    swDoc.ClearSelection2(true);
                }
            }

            // Create hole ejector rods
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut112 = null;
            SketchCut112 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(0, 0, 0, 0.017)));

            Feature Cut112 = null;
            Cut112 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, L, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A + S + B + U + C), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Core Clamping Plate.sldprt");

            // Close Document
            swDoc = null;
            swApp.CloseDoc("Core Clamping Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // Insert Guide Bush GBA-1
            object Plane12 = null;
            Component2 swComponent12;
            longstatus = swAssembly.InsertNewVirtualPart(Plane12, out swComponent12);
            boolstatus = swDoc.Extension.SelectByID2("Part11^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part11^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part11^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude

            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", -0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            SketchSegment Sketch12 = null;
            Sketch12 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d1_GB / 2)));
            Feature Extrude12 = null;
            Extrude12 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, A - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch121 = null;
            Sketch121 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, head_GB / 2)));
            Feature Extrude121 = null;
            Extrude121 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, hhead_GB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch122 = null;
            Sketch122 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d_GP / 2)));
            Feature Cut122 = null;
            Cut122 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, A - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Save
   
            boolstatus = swDoc.SaveAs(SaveLocation + "\\GBA-1.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("GBA-1.sldprt");

            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GBA-1-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


            Feature Pattern12;
            Pattern12 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP * 2, 2, x_GP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            LocalLinearPatternFeatureData swDefinition;
            swDefinition = Pattern12.GetDefinition();
            int[] swSkippedPattern = new int[1];
            swSkippedPattern[0] = 2;
            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern12.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);
            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GBA-1-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


            Feature Pattern121;
            Pattern121 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP + y1_GP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);
            
            // Insert Guide Pin GPA
            object Plane15 = null;
            Component2 swComponent15;
            longstatus = swAssembly.InsertNewVirtualPart(Plane15, out swComponent15);
            boolstatus = swDoc.Extension.SelectByID2("Part12^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part12^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part12^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch15 = null;
            Sketch15 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d_GP / 2)));
            Feature Extrude15 = null;
            Extrude15 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, B + S + A - 0.003, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch151 = null;
            Sketch151 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, head_GP / 2)));
            Feature Extrude151 = null;
            Extrude151 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_GP, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save

            boolstatus = swDoc.SaveAs(SaveLocation + "\\GPA.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("GPA.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GPA-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


            Feature Pattern15;
            Pattern15 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP * 2, 2, x_GP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));

            swDefinition = Pattern15.GetDefinition();

            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern15.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GPA-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


            Feature Pattern151;
            Pattern151 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP + y1_GP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);


            // Insert Mold counter bolts CB
            object Plane16 = null;
            Component2 swComponent16;
            longstatus = swAssembly.InsertNewVirtualPart(Plane16, out swComponent16);
            boolstatus = swDoc.Extension.SelectByID2("Part13^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part13^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part13^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch16 = null;
            Sketch16 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_CB, y_CB, 0, m_CB / 2000)));
            Feature Extrude16 = null;
            Extrude16 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, L + C + U + l_CB - hheadhole_CB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C + L - hheadhole_CB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch161 = null;
            Sketch161 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_CB, y_CB, 0, head_CB / 2)));
            Feature Extrude161 = null;
            Extrude161 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_CB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C + L - hheadhole_CB + hhead_CB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\CB-1.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("CB-1.sldprt");
            swDoc = swApp.ActiveDoc;

            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-1-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                    Feature Pattern161;
                    Pattern161 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB-y_TB, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);

                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-1-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                    Feature Pattern162;
                    Pattern162 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);

                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-1-2@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                    Feature Pattern163;
                    Pattern163 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_TB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);
                }
                else
                {
                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-1-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                    Feature Pattern164;
                    Pattern164 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(3, y_CB, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);
                }
            }
            else
            {
                // Linear Pattern
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("CB-1-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                Feature Pattern165;
                Pattern165 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }

            // Insert Ejector counter bolts EB
            object Plane17 = null;
            Component2 swComponent17;
            longstatus = swAssembly.InsertNewVirtualPart(Plane17, out swComponent17);
            boolstatus = swDoc.Extension.SelectByID2("Part14^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part14^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part14^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch17 = null;
            Sketch17 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_EB, y_EB, 0, m_EB / 2000)));
            Feature Extrude17 = null;
            Extrude17 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, l1_EB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C - spacer - hheadhole_EB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch171 = null;
            Sketch171 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_EB, y_EB, 0, head_EB / 2)));
            Feature Extrude171 = null;
            Extrude171 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_EB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C - spacer - hheadhole_EB + hhead_EB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\CB-2.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("CB-2.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            

            if (Molddim > 5554)
            {
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("CB-2-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);

                Feature Pattern171;
                Pattern171 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(3, y_EB, 2, x_EB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }
            else
            {
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("CB-2-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                Feature Pattern17;
                Pattern17 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_EB * 2, 2, x_EB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }
            // Insert Return Pin RPN
            object Plane18 = null;
            Component2 swComponent18;
            longstatus = swAssembly.InsertNewVirtualPart(Plane18, out swComponent18);
            boolstatus = swDoc.Extension.SelectByID2("Part15^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part15^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part15^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch18 = null;
            Sketch18 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_RP, y_RP, 0, d_RP / 2)));
            Feature Extrude18 = null;
            Extrude18 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, C + U + B - spacer - F, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C - spacer - F), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch181 = null;
            Sketch181 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_RP, y_RP, 0, head_RP / 2)));
            Feature Extrude181 = null;
            Extrude181 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_RP, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A + S + B + U + C - spacer - F), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\RPN.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("RPN.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("RPN-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);

            Feature Pattern18;
            Pattern18 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_RP * 2, 2, x_RP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);

            // Insert CB Cavity clamping
            object Plane22 = null;
            Component2 swComponent22;
            longstatus = swAssembly.InsertNewVirtualPart(Plane22, out swComponent22);
            boolstatus = swDoc.Extension.SelectByID2("Part16^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part16^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part16^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch22 = null;
            Sketch22 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_CB, y_CB, 0, m_CB / 2000)));
            Feature Extrude22 = null;
            Extrude22 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, T + l_CB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, - hheadhole_CB, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch221 = null;
            Sketch221 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_CB, y_CB, 0, head_CB / 2)));
            Feature Extrude221 = null;
            Extrude221 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, hhead_CB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, - hheadhole_CB + hhead_CB, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save

            boolstatus = swDoc.SaveAs(SaveLocation + "\\CB-3.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("CB-3.sldprt");
            swDoc = swApp.ActiveDoc;

            if (y_CB * 2000 > 179)
            {
                if ((Molddim == 5575) | (Molddim == 5580) | (Molddim == 6075) | (Molddim == 6080) | (Molddim == 6570) | (Molddim == 6575) | (Molddim == 6580) | (Molddim == 7070) | (Molddim == 7075) | (Molddim == 7080))
                {
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-3-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                    Feature Pattern221;
                    Pattern221 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB-y_TB, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);

                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-3-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                    Feature Pattern222;
                    Pattern222 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);

                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-3-2@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                    Feature Pattern223;
                    Pattern223 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_TB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);
                }
                else
                {
                    // Linear Pattern
                    boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                    boolstatus = swDoc.Extension.SelectByID2("CB-3-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                    Feature Pattern224;
                    Pattern224 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(3, y_CB, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                    swDoc.ClearSelection2(true);
                }
            }

                // Linear Pattern
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("CB-3-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                Feature Pattern225;
                Pattern225 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            
            // Insert Guide Bush GBB-2
            if (S != 0)
            {
                object Plane21 = null;
                Component2 swComponent21;
                longstatus = swAssembly.InsertNewVirtualPart(Plane21, out swComponent21);
                boolstatus = swDoc.Extension.SelectByID2("Part17^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
                swAssembly.OpenCompFile();

                // Open
                swDoc = swApp.OpenDoc6("Part17^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
                swDoc = swApp.ActiveDoc;

                swApp.ActivateDoc2("Part17^Assem1.sldprt", false, longstatus);
                swDoc = swApp.ActiveDoc;
                swDoc.ClearSelection2(true);
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);

                // Create Sketch - Extrude
                SketchSegment Sketch21 = null;
                Sketch21 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d1_GB / 2)));
                Feature Extrude21 = null;
                Extrude21 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, S - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + A) - 0.0005, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);

                SketchSegment Sketch211 = null;
                Sketch211 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d_GP / 2)));
                Feature Cut211 = null;
                Cut211 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, S - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + A) - 0.0005, false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
                // Save
                boolstatus = swDoc.SaveAs(SaveLocation + "\\GBB-2.sldprt");
                // Close Document
                swDoc = null;
                swApp.CloseDoc("GBB-2.sldprt");
                swDoc = swApp.ActiveDoc;

                // Linear Pattern
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("GBB-2-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                Feature Pattern21;
                Pattern21 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP * 2, 2, x_GP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
                swDefinition = Pattern21.GetDefinition();

                swDefinition.SkippedItemArray = swSkippedPattern;

                boolstatus = Pattern21.ModifyDefinition(swDefinition, swDoc, null);
                swDoc.ClearSelection2(true);


                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("GBB-2-1@Assem1", "COMPONENT", 0, 0, -0, true, 1, null, 0);


                Feature Pattern211;
                Pattern211 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP + y1_GP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }
            // ---------------------------------------------------------
            // Activate Assembly. End code
            swApp.ActivateDoc2("Assem1", false, longstatus);
            swDoc = swApp.ActiveDoc;

            boolstatus = swDoc.SaveAs(SaveLocation + "\\Die .sldasm");
            swDoc.ClearSelection2(true);

        }

    }
}
