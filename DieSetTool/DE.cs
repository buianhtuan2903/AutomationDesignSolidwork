using System;

using SolidWorks.Interop.sldworks;
using Microsoft.Office.Interop.Excel;


namespace DieSetTool
{
    class DEType
    {
        public double x_clamp;
        public double A;
        public double S;
        public double B;
        public double U;
        public double C;
        public double l_SPP;
        public string DataLocation;
        public string SaveLocation;
        public double Molddim;

        public void getdata( String combobox1data, String combobox2data, String combobox3data, String combobox4data, String combobox5data, String combobox6data, String combobox7data, String TB1data, String TB2data, String TB3data)
        {
            MainWindow run = new MainWindow();
            Molddim = (Convert.ToDouble(combobox1data)) ;
            x_clamp = (Convert.ToDouble(combobox2data))/1000 ;
            A = (Convert.ToDouble(combobox3data)) / 1000;
            S = (Convert.ToDouble(combobox4data)) / 1000;
            B = (Convert.ToDouble(combobox5data)) / 1000;
            U = (Convert.ToDouble(combobox6data)) / 1000;
            C = (Convert.ToDouble(combobox7data)) / 1000;
            l_SPP = (Convert.ToDouble(TB1data)) / 1000; 
            DataLocation = TB2data ;
            SaveLocation = TB3data ;
        }

        public void DETypeCode()
        {
            SldWorks swApp = new SldWorks(); ;
            swApp.Visible = true;
            ModelDoc2 swDoc = null;
            AssemblyDoc swAssembly = null;

            bool boolstatus = false;
            int longstatus = 0;
            int longwarnings = 0;
            int swErrors = 0;
            int swWarnings = 0;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            
            xlApp.Workbooks.Open(DataLocation);

            Workbook xlWB = xlApp.ActiveWorkbook;
            Worksheet xlWS = xlApp.ActiveSheet;

            double x_mold = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 2, false)) / 1000;
            double y_mold = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 3, false)) / 1000;

            double T = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 5, false)) / 1000;
            double R = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 6, false)) / 1000;
            double E = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 7, false)) / 1000;
            double F = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 8, false)) / 1000;
            double x_EF = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 9, false)) / 1000;
            double x_C = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 10, false)) / 1000;
            double L = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 11, false)) / 1000;

            double x_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"].Value2, 12, false)) / 2000;
            double y_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 13, false)) / 2000;
            double y1_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 14, false)) / 1000;
            double d_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 15, false)) / 1000;
            double head_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 16, false)) / 1000;
            double hhead_GP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 17, false)) / 1000;

            double d1_GB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 18, false)) / 1000;
            double head_GB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 19, false)) / 1000;
            double hhead_GB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 20, false)) / 1000;

            double x_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 21, false)) / 2000;
            double y_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 22, false)) / 2000;
            double y1_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 23, false)) / 1000;
            double d_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 24, false)) / 1000;
            double head_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 25, false)) / 1000;
            double hhead_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 26, false)) / 1000;
            double head2_SPP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 27, false)) / 1000;

            double x_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 28, false)) / 2000;
            double y_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 29, false)) / 2000;
            double d_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 30, false)) / 1000;
            double head_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 31, false)) / 1000;
            double hhead_RP = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 32, false)) / 1000;

            double spacer = 0.005;

            double x_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 33, false)) / 2000;
            double y_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 34, false)) / 2000;
            double m_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 35, false));
            double head_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 2, false)) / 1000;
            double hhead_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 3, false)) / 1000;
            double headhole_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 4, false)) / 1000;
            double hheadhole_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 5, false)) / 1000;
            double d1_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 6, false)) / 1000;
            double d2_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 7, false)) / 1000;
            double l_CB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_CB), xlWS.Range["A78:H88"], 8, false)) / 1000;

            double x_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 36, false)) / 2000;
            double y_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 37, false)) / 2000;
            double l1_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 39, false)) / 1000;
            double m_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 38, false));
            double head_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A78:H88"], 2, false)) / 1000;
            double hhead_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A78:H88"], 3, false)) / 1000;
            double headhole_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A78:H88"], 4, false)) / 1000;
            double hheadhole_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A78:H88"], 5, false)) / 1000;
            double d1_EB = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_EB), xlWS.Range["A78:H88"], 6, false)) / 1000;

            double d_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 40, false)) / 1000;
            double t_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 42, false)) / 1000;
            double m_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 43, false));
            double head_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_SPC), xlWS.Range["A78:H88"], 2, false)) / 1000;
            double hhead_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_SPC), xlWS.Range["A78:H88"], 3, false)) / 1000;
            double l2_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Molddim, xlWS.Range["A4:AZ74"], 44, false)) / 1000;
            double l_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_SPC), xlWS.Range["A78:H88"], 8, false)) / 1000;
            double d2_SPC = Convert.ToDouble(xlWS.Application.WorksheetFunction.VLookup(Convert.ToString(m_SPC), xlWS.Range["A78:H88"], 7, false)) / 1000;

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

            // Create Hole SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut11;

            SketchCut11 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - d_SPP / 2, y_SPP, 0)));
            SketchCut11 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - d_SPP / 2, -y_SPP, 0)));
            SketchCut11 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - d_SPP / 2, y_SPP, 0)));

            Feature Cut11 = null;
            Cut11 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, T, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            //  Create Head SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut12 = null;
            SketchCut12 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(-x_SPP, y_SPP, 0, (head_SPP / 2) + 0.0005)));
            SketchCut12 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(-x_SPP, -y_SPP, 0, (head_SPP / 2) + 0.0005)));
            SketchCut12 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, (head_SPP / 2) + 0.0005)));

            Feature Cut12 = null;
            Cut12 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, hhead_SPP, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create special SPP hole
            boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, 0, x_SPP, -y1_SPP, -1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d_SPP, T, -1, head_SPP + 0.001, hhead_SPP, 0, 1, 2.05948851735331, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            // Save
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Cavity Clamping Plate.sldprt");

            // Close Document
            swDoc = null;
            swApp.CloseDoc("Cavity Clamping Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // -------------------------------------
            // Insert Runner Plate
            object Plane2 = null;
            Component2 swComponent2;

            longstatus = swAssembly.InsertNewVirtualPart(Plane2, out swComponent2);
            boolstatus = swDoc.Extension.SelectByID2("Part2^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
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
            Array Sketch2;
            Sketch2 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
            Feature Extrude2 = null;
            Extrude2 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, R, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -T, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create hole GBB for SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut20 = null;
            SketchCut20 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - d1_GB / 2, y_SPP, 0)));
            SketchCut20 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - d1_GB / 2, -y_SPP, 0)));
            SketchCut20 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - d1_GB / 2, y_SPP, 0)));


            Feature Cut20 = null;
            Cut20 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, R, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -T, false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create special SPP hole
            boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, -T, x_SPP, -y1_SPP, -T - 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(2, 8, 143, "Ø0.15", 1, d1_GB, R, -1, 1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            // Save
          
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Runner Stripper Plate.sldprt");

            // Close Document
            swDoc = null;
            swApp.CloseDoc("Runner Stripper Plate.sldprt");
            swDoc = swApp.ActiveDoc;

            // ----------------------------------------
            // Insert Cavity Plate
            object Plane3 = null;
            Component2 swComponent3;

            longstatus = swAssembly.InsertNewVirtualPart(Plane3, out swComponent3);
            boolstatus = swDoc.Extension.SelectByID2("Part3^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part3^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part3^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            Array Sketch3;
            Sketch3 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
            Feature Extrude3 = null;
            Extrude3 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, A, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole GBA
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut30 = null;
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - d1_GB / 2, y_SPP, 0)));
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - d1_GB / 2, -y_SPP, 0)));
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - d1_GB / 2, y_SPP, 0)));

            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - d1_GB / 2, y_GP, 0)));
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - d1_GB / 2, -y_GP, 0)));
            SketchCut30 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - d1_GB / 2, y_GP, 0)));

            Feature Cut30 = null;
            Cut30 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, A, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R), false, false)));
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
            Cut31 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, hhead_GB, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Head GBA for SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut32 = null;
            SketchCut32 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - head_GB / 2 - 0.0005, y_SPP, 0)));
            SketchCut32 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - head_GB / 2 - 0.0005, -y_SPP, 0)));
            SketchCut32 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - head_GB / 2 - 0.0005, y_SPP, 0)));

            Feature Cut32 = null;
            Cut32 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, hhead_GB, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create special hole
            boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, -(T + R + A), x_SPP, -y1_SPP, -(T + R + A - 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_GB, A, -1, head_GB + 0.001, hhead_GB, 0, 1, 2.05948851735331, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            boolstatus = swDoc.Extension.SelectByRay(x_GP, -y1_GP, -(T + R), x_GP, -y1_GP, -(T + R + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_GB, A, -1, head_GB + 0.001, hhead_GB, 0, 1, 2.05948851735331, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

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
            boolstatus = swDoc.Extension.SelectByID2("Part4^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part4^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part4^Assem1.sldprt", false, longstatus);
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
                Extrude4 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, S, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A), false)));
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

                SketchCut40 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
                SketchCut40 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, -y_SPP, 0)));
                SketchCut40 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));

                Feature Cut40 = null;
                Cut40 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, S, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);

                // Create special hole
                boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, -(T + R + A), x_SPP, -y1_SPP, -(T + R + A + 1), 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(2, 8, 143, "Ø0.15", 1, head2_SPP + 0.002, S, -1, 1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);

                boolstatus = swDoc.Extension.SelectByRay(x_GP, -y1_GP, -(T + R + A), x_GP, -y1_GP, -(T + R + A + 1), 0.01, 2, false, 0, 0);
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
            boolstatus = swDoc.Extension.SelectByID2("Part5^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part5^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part5^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch  - Extrude
            Array Sketch5;
            Sketch5 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_mold / 2, y_mold / 2, 0)));
            Feature Extrude5 = null;
            Extrude5 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, B, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Hole SPP + GP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut50 = null;
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, -y_SPP, 0)));
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
            
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, y_GP, 0, -x_GP - d_GP / 2, y_GP, 0)));
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_GP, -y_GP, 0, -x_GP - d_GP / 2, -y_GP, 0)));
            SketchCut50 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_GP, y_GP, 0, x_GP - d_GP / 2, y_GP, 0)));
            
            Feature Cut50 = null;
            Cut50 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, B, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S), false, false)));
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
            Cut52 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, hhead_GP, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create special hole
            boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, -(T + R + A + S), x_SPP, -y1_SPP, -(T + R + A + S + 1), 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(2, 8, 143, "Ø0.15", 1, head2_SPP + 0.002, B, -1, 1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_GP, -y1_GP, -(T + R + A + S + B), x_GP, -y1_GP, -(T + R + A + S + B - 1), 0.01, 2, false, 0, 0);
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
            Cut53 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, B, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_CB, -(T + R + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_CB, -(T + R + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, y_CB, -(T + R + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_CB, -(T + R + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 1000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            if (y_CB * 2000 > 197)
            {
                boolstatus = swDoc.Extension.SelectByRay(x_CB, 0, -(T + R + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 2000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);


                boolstatus = swDoc.Extension.SelectByRay(-x_CB, 0, -(T + R + A + S + B), 0, 0, 1, 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_CB, l_CB + 0.006, -1, m_CB / 2000, l_CB + 0.003, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);
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
            boolstatus = swDoc.Extension.SelectByID2("Part6^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part6^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part6^Assem1.sldprt", false, longstatus);
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
                Extrude6 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, U, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B), false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);


                // Create Hole SPP
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);
                SketchSegment SketchCut60 = null;
                SketchCut60 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
                SketchCut60 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, -y_SPP, 0)));
                SketchCut60 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));

                Feature Cut60 = null;
                Cut60 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, U, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);

                // Create special hole
                boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, -(T + R + A + S + B), x_GP, -y1_GP, -(T + R + A + S + B + 1), 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(2, 8, 143, "Ø0.15", 1, head2_SPP + 0.002, U, -1, 1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
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
                Cut61 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, U, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B), false, false)));
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
                if (y_CB * 2000 > 197)
                {
                    SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, 0, 0, -x_CB - d1_CB / 2, 0, 0)));
                    SketchCut62 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, 0, 0, x_CB - d1_CB / 2, 0, 0)));
                }
                Feature Cut62 = null;
                Cut62 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, U, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B), false, false)));
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
            boolstatus = swDoc.Extension.SelectByID2("Part7^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
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
            Array Sketch7;
            Sketch7 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(x_mold / 2, -y_mold / 2, 0, x_mold / 2 - x_C, y_mold / 2, 0)));
            Feature Extrude7 = null;
            Extrude7 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut70 = null;
            SketchCut70 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
            SketchCut70 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, -y1_SPP, 0, x_SPP - head2_SPP / 2 - 0.001, -y1_SPP, 0)));


            Feature Cut70 = null;
            Cut70 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Hole Counter Bolt
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut71 = null;
            SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, y_CB, 0, x_CB - d1_CB / 2, y_CB, 0)));
            SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, -y_CB, 0, x_CB - d1_CB / 2, -y_CB, 0)));

            if (y_CB * 2000 > 197)
            {
                SketchCut71 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_CB, 0, 0, x_CB - d1_CB / 2, 0, 0)));
            }


            Feature Cut71 = null;
            Cut71 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U), false, false)));
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
            boolstatus = swDoc.Extension.SelectByID2("Part8^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
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
            Array Sketch8;
            Sketch8 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(-x_mold / 2, y_mold / 2, 0, -x_mold / 2 + x_C, -y_mold / 2, 0)));
            Feature Extrude8 = null;
            Extrude8 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Hole SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut80 = null;
            SketchCut80 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
            SketchCut80 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, -y_SPP, 0)));


            Feature Cut80 = null;
            Cut80 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Create Hole Counter Bolt
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut81 = null;
            SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, y_CB, 0, -x_CB - d1_CB / 2, y_CB, 0)));
            SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, -y_CB, 0, -x_CB - d1_CB / 2, -y_CB, 0)));

            if (y_CB * 2000 > 197)
            {
                SketchCut81 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_CB, 0, 0, -x_CB - d1_CB / 2, 0, 0)));
            }

            Feature Cut81 = null;
            Cut81 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, C, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U), false, false)));
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
            boolstatus = swDoc.Extension.SelectByID2("Part9^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
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
            Array Sketch9;
            Sketch9 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_EF / 2, y_mold / 2, 0)));
            Feature Extrude9 = null;
            Extrude9 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, E, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C - spacer - E - F), false)));
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
            Cut90 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, E, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U + C - spacer - E - F), false, false)));
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
            Cut91 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, hhead_RP, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U + C - spacer - F), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            // Create Hole Ejector Bolt
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut92 = null;
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(-x_EB, y_EB, 0, m_EB / 2000)));
            
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_EB, -y_EB, 0, m_EB / 2000)));
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_EB, y_EB, 0, x_EB - (m_EB / 2000), y_EB, 0)));
            SketchCut92 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_EB, -y_EB, 0,(-x_EB) - (m_EB / 2000), -y_EB, 0)));
            

            Feature Cut92 = null;
            Cut92 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, E, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U + C - spacer - E - F), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

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
            boolstatus = swDoc.Extension.SelectByID2("Part10^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
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
            Array Sketch10;
            Sketch10 = ((Array)(swDoc.SketchManager.CreateCenterRectangle(0, 0, 0, x_EF / 2, y_mold / 2, 0)));
            Feature Extrude10 = null;
            Extrude10 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, F, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C - spacer - F), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_EB, y_EB, -(T + R + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_EB, -y_EB, -(T + R + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_EB, y_EB, -(T + R + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_EB, -y_EB, -(T + R + A + S + B + U + C - spacer), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_EB, F, -1, headhole_EB, hheadhole_EB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);
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
            boolstatus = swDoc.Extension.SelectByID2("Part11^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.FixComponent();
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
            Array Sketch11;
            Sketch11 = ((Array)(swDoc.SketchManager.CreateCornerRectangle(-x_clamp / 2, -y_mold / 2, 0, x_clamp / 2, y_mold / 2, 0)));
            Feature Extrude11 = null;
            Extrude11 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, L, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C), false)));
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
                Cut110 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, L - 0.025, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U + C), false, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);
            }

            // Hole Wizard counterbore
            boolstatus = swDoc.Extension.SelectByRay(-x_CB, y_CB, -(T + R + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(-x_CB, -y_CB, -(T + R + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_CB, y_CB, -(T + R + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            boolstatus = swDoc.Extension.SelectByRay(x_CB, -y_CB, -(T + R + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            if (y_CB * 2000 > 197)
            {
                boolstatus = swDoc.Extension.SelectByRay(x_CB, 0, -(T + R + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);


                boolstatus = swDoc.Extension.SelectByRay(-x_CB, 0, -(T + R + A + S + B + U + C + L), 0, 0, 1, 0.01, 2, false, 0, 0);
                swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d1_CB, L, -1, headhole_CB, hheadhole_CB, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
                swSketchFeature = swHoleFeature.GetFirstSubFeature();
                swDoc.ClearSelection2(true);
            }

            // Create Hole SPP
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut111 = null;
            SketchCut111 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
            SketchCut111 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(-x_SPP, -y_SPP, 0, -x_SPP - head2_SPP / 2 - 0.001, -y_SPP, 0)));
            SketchCut111 = ((SketchSegment)(swDoc.SketchManager.CreateCircle(x_SPP, y_SPP, 0, x_SPP - head2_SPP / 2 - 0.001, y_SPP, 0)));
            
            Feature Cut111 = null;
            Cut111 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, L, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U + C), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            
            // Create special SPP hole
            boolstatus = swDoc.Extension.SelectByRay(x_SPP, -y1_SPP, -(T + R + A + S + B + U + C), x_SPP, -y1_SPP, -(T + R + A + S + B + U + C) - 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(2, 8, 143, "Ø0.15", 1, head2_SPP + 0.002, L, -1, 1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);

            // Create hole ejector rods
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);
            SketchSegment SketchCut112 = null;
            SketchCut112 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(0, 0, 0, 0.017)));

            Feature Cut112 = null;
            Cut112 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, L, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A + S + B + U + C), false, false)));
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

            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            SketchSegment Sketch12 = null;
            Sketch12 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d1_GB / 2)));
            Feature Extrude12 = null;
            Extrude12 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, A - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch121 = null;
            Sketch121 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, head_GB / 2)));
            Feature Extrude121 = null;
            Extrude121 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, hhead_GB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch122 = null;
            Sketch122 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d_GP / 2)));
            Feature Cut122 = null;
            Cut122 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, A - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R), false, false)));
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
            boolstatus = swDoc.Extension.SelectByID2("GBA-1-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


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
            boolstatus = swDoc.Extension.SelectByID2("GBA-1-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern121;
            Pattern121 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP + y1_GP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);

            // Insert Guide Bush GBA-2
            object Plane13 = null;
            Component2 swComponent13;
            longstatus = swAssembly.InsertNewVirtualPart(Plane13, out swComponent13);
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
            SketchSegment Sketch13 = null;
            Sketch13 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, d1_GB / 2)));
            Feature Extrude13 = null;
            Extrude13 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, A - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch131 = null;
            Sketch131 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, head_GB / 2)));
            Feature Extrude131 = null;
            Extrude131 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_GB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch132 = null;
            Sketch132 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, d_SPP / 2)));
            Feature Cut132 = null;
            Cut132 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, true, 0, 0, A - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A), false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
           
            boolstatus = swDoc.SaveAs(SaveLocation + "\\GBA-2.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("GBA-2.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GBA-2-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);
        
            Feature Pattern13;
            Pattern13 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP * 2, 2, x_SPP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            
            swDefinition = Pattern13.GetDefinition();
            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern13.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);
            
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GBA-2-1@Assem1", "COMPONENT", 1.80691969317763E-02, 3.74688074136884E-02, -0.02743476584169, true, 1, null, 0);


            Feature Pattern131;
            Pattern131 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP + y1_SPP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);

            // Insert Guide Bush GBB-1
            object Plane14 = null;
            Component2 swComponent14;
            longstatus = swAssembly.InsertNewVirtualPart(Plane14, out swComponent14);
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
            SketchSegment Sketch14 = null;
            Sketch14 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, d1_GB / 2)));
            Feature Extrude14 = null;
            Extrude14 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, R - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -T - 0.0005, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch141 = null;
            Sketch141 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, d_GP / 2)));
            Feature Cut141 = null;
            Cut141 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, R - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -T - 0.0005, false, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
      
            boolstatus = swDoc.SaveAs(SaveLocation + "\\GBB-1.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("GBB-1.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GBB-1-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern14;
            Pattern14 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP * 2, 2, x_SPP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));


            swDefinition = Pattern14.GetDefinition();
            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern14.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GBB-1-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern141;
            Pattern141 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP + y1_SPP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);
            // Insert Guide Pin GPA
            object Plane15 = null;
            Component2 swComponent15;
            longstatus = swAssembly.InsertNewVirtualPart(Plane15, out swComponent15);
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
            SketchSegment Sketch15 = null;
            Sketch15 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d_GP / 2)));
            Feature Extrude15 = null;
            Extrude15 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, B + S + A - 0.003, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch151 = null;
            Sketch151 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, head_GP / 2)));
            Feature Extrude151 = null;
            Extrude151 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_GP, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B), false)));
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
            boolstatus = swDoc.Extension.SelectByID2("GPA-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern15;
            Pattern15 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP * 2, 2, x_GP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));

            swDefinition = Pattern15.GetDefinition();

            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern15.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("GPA-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern151;
            Pattern151 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP + y1_GP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);


            // Insert Mold counter bolts CB
            object Plane16 = null;
            Component2 swComponent16;
            longstatus = swAssembly.InsertNewVirtualPart(Plane16, out swComponent16);
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
            SketchSegment Sketch16 = null;
            Sketch16 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_CB, y_CB, 0, m_CB / 2000)));
            Feature Extrude16 = null;
            Extrude16 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, L + C + U + l_CB - hheadhole_CB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C + L - hheadhole_CB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch161 = null;
            Sketch161 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_CB, y_CB, 0, head_CB / 2)));
            Feature Extrude161 = null;
            Extrude161 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_CB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C + L - hheadhole_CB + hhead_CB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
        
            boolstatus = swDoc.SaveAs(SaveLocation + "\\CB-1.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("CB-1.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            if (y_CB * 2000 > 197)
            {
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("CB-1-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                Feature Pattern161;
                Pattern161 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(3, y_CB, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }
            else
            {
                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("CB-1-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);

                Feature Pattern162;
                Pattern162 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_CB * 2, 2, x_CB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }

            // Insert Ejector counter bolts EB
            object Plane17 = null;
            Component2 swComponent17;
            longstatus = swAssembly.InsertNewVirtualPart(Plane17, out swComponent17);
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
            SketchSegment Sketch17 = null;
            Sketch17 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_EB, y_EB, 0, m_EB / 2000)));
            Feature Extrude17 = null;
            Extrude17 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, l1_EB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C - spacer - hheadhole_EB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch171 = null;
            Sketch171 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_EB, y_EB, 0, head_EB / 2)));
            Feature Extrude171 = null;
            Extrude171 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_EB, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C - spacer - hheadhole_EB + hhead_EB), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
            
            boolstatus = swDoc.SaveAs(SaveLocation + "\\CB-2.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("CB-2.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("CB-2-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern17;
            Pattern17 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_EB * 2, 2, x_EB * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);

            // Insert Return Pin RPN
            object Plane18 = null;
            Component2 swComponent18;
            longstatus = swAssembly.InsertNewVirtualPart(Plane18, out swComponent18);
            boolstatus = swDoc.Extension.SelectByID2("Part18^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part18^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part18^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch18 = null;
            Sketch18 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_RP, y_RP, 0, d_RP / 2)));
            Feature Extrude18 = null;
            Extrude18 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, C + U + B - spacer - F, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C - spacer - F), false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch181 = null;
            Sketch181 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_RP, y_RP, 0, head_RP / 2)));
            Feature Extrude181 = null;
            Extrude181 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_RP, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A + S + B + U + C - spacer - F), false)));
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
            boolstatus = swDoc.Extension.SelectByID2("RPN-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern18;
            Pattern18 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_RP * 2, 2, x_RP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);

            // Insert Support Pin SPN
            object Plane19 = null;
            Component2 swComponent19;
            longstatus = swAssembly.InsertNewVirtualPart(Plane19, out swComponent19);
            boolstatus = swDoc.Extension.SelectByID2("Part19^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part19^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part19^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch19 = null;
            Sketch19 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, d_SPP / 2)));
            Feature Extrude19 = null;
            Extrude19 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, l_SPP, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch191 = null;
            Sketch191 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, head_SPP / 2)));
            Feature Extrude191 = null;
            Extrude191 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, hhead_SPP, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByRay(x_SPP, y_SPP, -l_SPP, 0, 0, 1, 0.01, 2, false, 0, 0);
            swHoleFeature = ((Feature)(swDoc.FeatureManager.HoleWizard5(0, 8, 139, "M5", 0, d2_SPC, l_SPC + 0.003, -1, m_SPC / 1000, l_SPC, 0, 1, 2.05948851735331, 0, 0, 0, 0, 0, 0, 0, "", false, true, true, true, true, false)));
            swSketchFeature = swHoleFeature.GetFirstSubFeature();
            swDoc.ClearSelection2(true);
            // Save
      
            boolstatus = swDoc.SaveAs(SaveLocation + "\\SPN.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("SPN.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("SPN-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern19;
            Pattern19 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP * 2, 2, x_SPP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));


            swDefinition = Pattern19.GetDefinition();

            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern19.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("SPN-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern191;
            Pattern191 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP + y1_SPP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);


            // Insert Support Pin Collars SPC
            object Plane20 = null;
            Component2 swComponent20;
            longstatus = swAssembly.InsertNewVirtualPart(Plane20, out swComponent20);
            boolstatus = swDoc.Extension.SelectByID2("Part20^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
            swAssembly.OpenCompFile();

            // Open
            swDoc = swApp.OpenDoc6("Part20^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
            swDoc = swApp.ActiveDoc;

            swApp.ActivateDoc2("Part20^Assem1.sldprt", false, longstatus);
            swDoc = swApp.ActiveDoc;
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.ClearSelection2(true);

            // Create Sketch - Extrude
            SketchSegment Sketch20 = null;
            Sketch20 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, d_SPC / 2)));
            Feature Extrude20 = null;
            Extrude20 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, t_SPC, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -l_SPP, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);

            SketchSegment Sketch201 = null;
            Sketch201 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, head_SPC / 2)));
            Feature Extrude201 = null;
            Extrude201 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, hhead_SPC, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -l_SPP - l2_SPC, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            SketchSegment Sketch202 = null;
            Sketch202 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, m_SPC / 2000)));
            Feature Extrude202 = null;
            Extrude202 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, l_SPC + t_SPC + hhead_SPC, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -l_SPP - l2_SPC, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);


            SketchSegment Sketch203 = null;
            Sketch203 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_SPP, y_SPP, 0, head_SPC / 2 + 0.002)));
            Feature Extrude203 = null;
            Extrude203 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, l2_SPC - hhead_SPC - t_SPC, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -l_SPP - l2_SPC + hhead_SPC, false)));
            swDoc.SelectionManager.EnableContourSelection = false;
            swDoc.ClearSelection2(true);
            // Save
            boolstatus = swDoc.Save3(1, swErrors, swWarnings);
            boolstatus = swDoc.SaveAs(SaveLocation + "\\SPC.sldprt");
            // Close Document
            swDoc = null;
            swApp.CloseDoc("SPC.sldprt");
            swDoc = swApp.ActiveDoc;

            // Linear Pattern
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Right Plane", "PLANE", 0, 0, 0, true, 4, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("SPC-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern20;
            Pattern20 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP * 2, 2, x_SPP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));

            swDefinition = Pattern20.GetDefinition();

            swDefinition.SkippedItemArray = swSkippedPattern;

            boolstatus = Pattern20.ModifyDefinition(swDefinition, swDoc, null);
            swDoc.ClearSelection2(true);


            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("SPC-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


            Feature Pattern201;
            Pattern201 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_SPP + y1_SPP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
            swDoc.ClearSelection2(true);

            // Insert Guide Bush GBB-2
            if (S != 0)
            {
                object Plane21 = null;
                Component2 swComponent21;
                longstatus = swAssembly.InsertNewVirtualPart(Plane21, out swComponent21);
                boolstatus = swDoc.Extension.SelectByID2("Part21^Assem1-1@Assem1", "COMPONENT", 0, 0, 0, false, 0, null, 0);
                swAssembly.OpenCompFile();

                // Open
                swDoc = swApp.OpenDoc6("Part21^Assem1.sldprt", 1, 0, "", longstatus, longwarnings);
                swDoc = swApp.ActiveDoc;

                swApp.ActivateDoc2("Part21^Assem1.sldprt", false, longstatus);
                swDoc = swApp.ActiveDoc;
                swDoc.ClearSelection2(true);
                swDoc.SketchManager.InsertSketch(true);
                boolstatus = swDoc.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
                swDoc.ClearSelection2(true);

                // Create Sketch - Extrude
                SketchSegment Sketch21 = null;
                Sketch21 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d1_GB / 2)));
                Feature Extrude21 = null;
                Extrude21 = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, S - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 3, -(T + R + A) - 0.0005, false)));
                swDoc.SelectionManager.EnableContourSelection = false;
                swDoc.ClearSelection2(true);

                SketchSegment Sketch211 = null;
                Sketch211 = ((SketchSegment)(swDoc.SketchManager.CreateCircleByRadius(x_GP, y_GP, 0, d_GP / 2)));
                Feature Cut211 = null;
                Cut211 = ((Feature)(swDoc.FeatureManager.FeatureCut4(true, false, false, 0, 0, S - 0.001, 0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 3, -(T + R + A) - 0.0005, false, false)));
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
                boolstatus = swDoc.Extension.SelectByID2("GBB-2-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


                Feature Pattern21;
                Pattern21 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP * 2, 2, x_GP * 2, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
                swDefinition = Pattern21.GetDefinition();

                swDefinition.SkippedItemArray = swSkippedPattern;

                boolstatus = Pattern21.ModifyDefinition(swDefinition, swDoc, null);
                swDoc.ClearSelection2(true);


                boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, true, 2, null, 0);
                boolstatus = swDoc.Extension.SelectByID2("GBB-2-1@Assem1", "COMPONENT", 0, 0, 0, true, 1, null, 0);


                Feature Pattern211;
                Pattern211 = ((Feature)(swDoc.FeatureManager.FeatureLinearPattern5(2, y_GP + y1_GP, 0, 0, true, true, "NULL", "NULL", false, false, false, false, false, false, true, true, false, false, 0, 0, false, false)));
                swDoc.ClearSelection2(true);
            }
            // ---------------------------------------------------------
            // Activate Assembly. End code
            swApp.ActivateDoc2("Assem1", false, longstatus);
            swDoc = swApp.ActiveDoc;
       
            boolstatus = swDoc.SaveAs(SaveLocation + "\\Die set.sldasm");
            
            swDoc.ClearSelection2(true);

        }
    }
}
