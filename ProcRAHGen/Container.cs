using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcRAHGen
{
    class Container
    {
        public static int MINSPAN = 4;

        private int x, y, w, h;
        private Container Lc, Rc;
        private Room room;

        public Container(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public bool split()
        {
            return (w / h > 1 ? splitW() : splitH());
        }

        private bool splitW()
        {
            // if we can't even split it in half, don't bother with any of this
            if (w / 2 < MINSPAN)
                return false;

            int lx, ly, lw, lh, rx, ry, rw, rh;
            Random rnd = new Random();
            int modifier = rnd.Next() % 2 == 1 ? 1 : -1;
            int wiggle = modifier * (w - 2 * MINSPAN);

            lx = x;
            ly = y;
            lw = w / 2 + wiggle;
            lh = h;
            
            rx = lw + 1;
            ry = y;
            rw = w - lw;
            rh = h;

            Lc = new Container(lx, ly, lw, lh);
            Rc = new Container(rx, ry, rw, rh);

            return true;
        }

        private bool splitH()
        {
            // if we can't even split it in half, don't bother with any of this
            if (h / 2 < MINSPAN)
                return false;

            int lx, ly, lw, lh, rx, ry, rw, rh;
            Random rnd = new Random();
            int modifier = rnd.Next() % 2 == 1 ? 1 : -1;
            // wiggle is how many units we can swing the split by while still statisfying the MINSPAN
            int wiggle = modifier * (h - 2 * MINSPAN);

            lx = x;
            ly = y;
            lw = w;
            lh = h / 2 + wiggle;

            rx = x;
            ry = lh + 1;
            rw = w;
            rh = h - lh;

            // sticking with L/R naming convention for s&g
            Lc = new Container(lx, ly, lw, lh);
            Rc = new Container(rx, ry, rw, rh);

            return true;
        }

        public void genRoom()
        {
            Random rnd = new Random();
            // figure out how much we can shrink container in w, h and give a chance to shrink
            int shrinkW = rnd.Next(0, w - MINSPAN);
            int shrinkH = rnd.Next(0, h - MINSPAN);



        }
    }
}
