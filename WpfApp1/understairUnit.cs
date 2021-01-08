using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class understairDrawerUnit
    {
        public int baseWidth = 0;
        public int sideHeight = 0;
        public int kicker = 0;
        public int bottomUpstandHeight = 0;
        public int flatTopWidth = 0;
        public int cuttingAngle = 0;
        public int drawerNumber = 3;
        public bool isdoubleDoor;
        public int tallUnitWidth = 500;
        public int depth;
        public int drawerSectionWidth;
        public firstDrawerSectionUnit firstDrawerSectionUnit = new firstDrawerSectionUnit();
        public secondDrawerSectionUnit secondDrawerSectionUnit = new secondDrawerSectionUnit();
        public thirdDrawerSectionUnit thirdDrawerSectionUnit = new thirdDrawerSectionUnit();
        public tallUnit tallUnit = new tallUnit();

        public understairDrawerUnit(int baseWidthP, int sideHeightP, int kickerP, int bottomUpstandHeightP, 
            int flatTopWidthP, int angleP, int drawerNumberP, bool isdoubleDoorP, int tallUnitWidthP,
            int depthP, int drawerSectionWidthP)
        {
            baseWidth = baseWidthP;
            sideHeight = sideHeightP;
            kicker = kickerP;
            bottomUpstandHeight = bottomUpstandHeightP;
            flatTopWidth = flatTopWidthP;
            cuttingAngle = angleP;
            drawerNumber = drawerNumberP;
            isdoubleDoor = isdoubleDoorP;
            tallUnitWidth = tallUnitWidthP;
            depth = depthP;
            drawerSectionWidth = drawerSectionWidthP;
        }

        public void getCuttingList(understairDrawerUnit understairDrawerUnit )
        {
            var cutList = new List<cut>();
            cutList.AddRange(getFirstDrawerUnit(understairDrawerUnit.kicker, understairDrawerUnit.tallUnitWidth, understairDrawerUnit.baseWidth,
                understairDrawerUnit.cuttingAngle, understairDrawerUnit.isdoubleDoor, understairDrawerUnit.depth,
                understairDrawerUnit.bottomUpstandHeight, understairDrawerUnit.drawerNumber, understairDrawerUnit.drawerSectionWidth
                ));
            cutList.AddRange(getSecondDrawerUnit(firstDrawerSectionUnit.largeSideToLong, firstDrawerSectionUnit.unitWidth, cuttingAngle));
            int largestDrawerSize = secondDrawerSectionUnit.largeSideToLong;
            if (drawerNumber == 6)
            {
                cutList.AddRange(getThirdDrawerUnit(secondDrawerSectionUnit.largeSideToLong, firstDrawerSectionUnit.unitWidth, cuttingAngle));
                largestDrawerSize = thirdDrawerSectionUnit.largeSideToLong;
            }
            cutList.AddRange(getTallUnit(understairDrawerUnit.tallUnitWidth, largestDrawerSize,
                understairDrawerUnit.cuttingAngle, understairDrawerUnit.isdoubleDoor, understairDrawerUnit.depth));
            cutList.AddRange(GetDrawers(firstDrawerSectionUnit.unitWidth, understairDrawerUnit.depth, understairDrawerUnit.drawerNumber));
            cutList.AddRange(GetDoorsrs(firstDrawerSectionUnit.unitWidth,
                tallUnit.largeSideToLong, tallUnit.unitWidth));
            PrintOut(cutList);
            MessageBox.Show("done");
        }

        private void PrintOut(List<cut> cutList)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\suzco\Documents\c#\temp\tester.txt"))
            {
                foreach (cut line in cutList)
                {
                    file.WriteLine(line.title);
                    if(line.toLong)
                        file.WriteLine(line.length + " * " + line.width + " * " + line.numberOf + " long" );
                    else
                        file.WriteLine(line.length + " * " + line.width + " * " + line.numberOf);
                }
            }
        }

        private IEnumerable<cut> GetDoorsrs(int unitWidth1, int largeSideToLong, int unitWidth3)
        {
            List<cut> dooers = new List<cut>();
            dooers.Add(new cut(450, unitWidth1 - 4, drawerNumber, false, "Door"));
            dooers.Add(new cut(largeSideToLong, tallUnit.unitWidth - 4, 1, false, "Door"));
            return dooers;
        }

        private IEnumerable<cut> GetDrawers(int unitWidth, int depth, int drwerNumber)
        {
            List<cut> drawers = new List<cut>();
            if(drwerNumber == 3)
            {
                drawers.AddRange(GetDrawersByNumber(unitWidth, depth, 4, 2, 6, drwerNumber));
            }
            else if(drwerNumber == 5)
            {
                drawers.AddRange(GetDrawersByNumber(unitWidth, depth, 6, 2, 10, drwerNumber));
            }
            else
            {
                drawers.AddRange(GetDrawersByNumber(unitWidth, depth, 9, 3, 12, drwerNumber));
            }
            return drawers;
        }

        private IEnumerable<cut> GetDrawersByNumber(int unitWidth, int depth, int bigLong, int smallLong, int shorts, int drwrNumber)
        {
            List<cut> drawers = new List<cut>();
            drawers.Add(new cut(250, depth - 50, bigLong, false, "drawer"));
            drawers.Add(new cut(100, depth - 50, smallLong, false, "drawer"));
            drawers.Add(new cut(250, unitWidth - 64, shorts, false, "drawer"));
            drawers.Add(new cut(unitWidth - 64, (depth - 50) - 36, drwrNumber, false, "drawer"));
            return drawers;
        }

        private List<cut> getTallUnit(int tallUnitWidth, int largestDrawerSize, int angle, bool isdoubleDoor, int depth)
        {
            var tallUnitList = new List<cut>();  // 
            tallUnit.smallSideToLong = getToTheLongLong(largestDrawerSize, 18, angle);
            tallUnit.largeSideToLong = getToTheLongLong(tallUnit.smallSideToLong, tallUnitWidth - 18, cuttingAngle);
            tallUnit.baseBoard = tallUnitWidth - 36;
            tallUnit.top = GetHyp(cuttingAngle, tallUnitWidth);
            tallUnit.unitWidth = tallUnitWidth;
            tallUnitList.Add(new cut(tallUnit.smallSideToLong, depth, 1, true, "Tall unit"));
            tallUnitList.Add(new cut(tallUnit.largeSideToLong, depth, 1, true, "Tall unit"));
            tallUnitList.Add(new cut(tallUnit.baseBoard, depth, 1, false, "Tall unit"));
            tallUnitList.Add(new cut(tallUnit.top, depth, 1, false, "Tall unit"));
            tallUnitList.Add(new cut(tallUnit.largeSideToLong - getOpposite(cuttingAngle, 18), depth, 1, true, "Tall unit"));
            return tallUnitList;
        }

        private List<cut> getThirdDrawerUnit(int secondUnitLongSide, int unitWidth, int angle)
        {
            var thirdDrawerUnit = new List<cut>();
            thirdDrawerSectionUnit.smallSideToLong = getToTheLongLong(secondUnitLongSide, 18, angle);
            thirdDrawerSectionUnit.largeSideToLong = getToTheLongLong(thirdDrawerSectionUnit.smallSideToLong, unitWidth -18, angle);
            thirdDrawerSectionUnit.baseBoard = firstDrawerSectionUnit.baseBoard;
            thirdDrawerSectionUnit.supports = firstDrawerSectionUnit.supports;
            thirdDrawerUnit.Add(new cut(thirdDrawerSectionUnit.smallSideToLong, depth, 1, true, "Third drawer unit"));
            thirdDrawerUnit.Add(new cut(thirdDrawerSectionUnit.largeSideToLong, 90, 2, true, "Third drawer unit"));
            thirdDrawerUnit.Add(new cut(thirdDrawerSectionUnit.baseBoard, depth, 1, false, "Third drawer unit"));
            thirdDrawerUnit.Add(new cut(thirdDrawerSectionUnit.supports, depth, 4, false, "Third drawer unit"));
            return thirdDrawerUnit;
        }

        private List<cut> getSecondDrawerUnit(int firstUnitLongSide, int unitWidth, int angle)
        {
            var secondDrawerUnit = new List<cut>();
            secondDrawerSectionUnit.smallSideToLong = firstUnitLongSide + getOpposite(90 - angle, 18); // getToTheLongLong(firstUnitLongSide, 18, angle);
            secondDrawerSectionUnit.largeSideToLong = getToTheLongLong(secondDrawerSectionUnit.smallSideToLong, unitWidth -18, angle);
            secondDrawerSectionUnit.baseBoard = firstDrawerSectionUnit.baseBoard;
            secondDrawerSectionUnit.supports = firstDrawerSectionUnit.supports;
            secondDrawerUnit.Add(new cut(secondDrawerSectionUnit.smallSideToLong, depth, 1, true, "Second drawer unit"));
            secondDrawerUnit.Add(new cut(secondDrawerSectionUnit.largeSideToLong, 90, 2, true, "Second drawer unit"));
            secondDrawerUnit.Add(new cut(secondDrawerSectionUnit.baseBoard, depth, 1, false, "Second drawer unit"));
            secondDrawerUnit.Add(new cut(secondDrawerSectionUnit.supports, depth, 3, false, "Second drawer unit"));
            return secondDrawerUnit;
        }

        private List<cut> getFirstDrawerUnit(int kicker, int tallUnitDoorWidth, int baseWidth, int cuttingAngle, bool isDoubleDoor, int depth,
            int bottomUpstandHeight, int drawerNumber, int drawerSectionWidth)
        {
            var smallDrawerUnit = new List<cut>();
            //bottomUpstandHeight = GetLessThirty(baseWidth, bottomUpstandHeight, drawerSectionWidth, cuttingAngle, sideHeight, tallUnitDoorWidth);
            if (isdoubleDoor) {
                if (drawerNumber == 3)
                {
                    firstDrawerSectionUnit.unitWidth = drawerSectionWidth / 2;
                }
                else
                {
                    firstDrawerSectionUnit.unitWidth = drawerSectionWidth / 3;
                }
               // bottomUpstandHeight = GetLessThirty(baseWidth, bottomUpstandHeight, drawerSectionWidth, cuttingAngle,
                    //sideHeight, tallUnitDoorWidth);
                int toTheInitialLong = GetLessThirty(baseWidth, bottomUpstandHeight, drawerSectionWidth, cuttingAngle,
                    sideHeight, tallUnitDoorWidth);// getToTheLong(bottomUpstandHeight, cuttingAngle);
                firstDrawerSectionUnit.smallSideToLong = toTheInitialLong;
                firstDrawerSectionUnit.largeSideToLong = getToTheLongLong(toTheInitialLong, firstDrawerSectionUnit.unitWidth - 18, cuttingAngle);
                firstDrawerSectionUnit.baseBoard = firstDrawerSectionUnit.unitWidth - 36;
                firstDrawerSectionUnit.supports = firstDrawerSectionUnit.unitWidth - 36;
            }
            smallDrawerUnit.Add(new cut(firstDrawerSectionUnit.smallSideToLong, depth, 1, true, "First drawer unit"));
            smallDrawerUnit.Add(new cut(firstDrawerSectionUnit.largeSideToLong, 90, 2, true, "First drawer unit"));
            smallDrawerUnit.Add(new cut(firstDrawerSectionUnit.baseBoard, depth, 1, false, "First drawer unit"));
            smallDrawerUnit.Add(new cut(firstDrawerSectionUnit.supports, 90, 1, false, "First drawer unit"));
            return smallDrawerUnit;
        }

        private int GetLessThirty(int baseWidth, int bottomUpstandHeight, int drawerSectionWidth, int cuttingAngle,
            int sideHeight, int tallUnitDoorWidth)
        {
            // get the adj from opposite
            int fullBase = getAdjasent(90 - cuttingAngle, sideHeight);// Convert.ToInt32(sideHeight / Math.Tan(90 - cuttingAngle * (Math.PI / 180)));
            //get oppp from adj
            int gg = (fullBase - (30 + tallUnitDoorWidth + drawerSectionWidth));
            int newLowHeight = getOpposite(90 - cuttingAngle, gg); //Convert.ToInt32(gg * Math.Tan(90 - cuttingAngle * (Math.PI / 180)));
            int lessThirty = newLowHeight - getHypot(cuttingAngle, 30); // less top 30mm gap
            int lessTopRail = lessThirty - getHypot(cuttingAngle, 18);
            int vv = getOpposite(90 - cuttingAngle, 18);
            return (lessTopRail + vv) - kicker;// get to the long of mdf
        }

        private int getToTheLongLong(int smallSideToLong, int unitWidth, int angle)
        {
            int hh = getOpposite(90 - angle, unitWidth);
            return smallSideToLong + getOpposite(90 - angle, unitWidth);
        }

        private int getHypot(int angle, int opposite)
        {
            return Convert.ToInt32(opposite / Math.Sin(angle * (Math.PI / 180)));
        }

        private int getAdjasent(int angle, int opposite)
        {
            return Convert.ToInt32(opposite / Math.Tan(angle * (Math.PI / 180)));
        }

        private int getOpposite(int angle, int adjasent)
        {
            return Convert.ToInt32(adjasent * Math.Tan(angle * (Math.PI / 180)));
        }

        private int GetHyp(int angle, int adjasent)
        {
            return Convert.ToInt32(adjasent / Math.Cos(angle * (Math.PI / 180)));
        }
    }
}
