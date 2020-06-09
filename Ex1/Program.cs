using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ex1
{
    class Program
    {
        private struct Sphere
        {
            public Sphere(double _x, double _y, double _z, double _r)
            {
                x = _x;
                y = _y;
                z = _z;
                r = _r;
                Connected = false;
            }

            public Sphere(Sphere sphere)
            {
                x = sphere.x;
                y = sphere.y;
                z = sphere.z;
                r = sphere.r;
                Connected = sphere.Connected;
            }

            public double x;
            public double y;
            public double z;
            public double r;

            public bool Connected { get; private set; }

            public void SetConnected(bool value)
            {
                Connected = value;
            }
        }

        static void Main(string[] args)
        {
            int result;
            using (StreamReader streamReader = new StreamReader("input.txt"))
            {
                string s = streamReader.ReadLine();
                char[] s1 = s.Trim().ToCharArray();
                List<Sphere> spheres = new List<Sphere>();
                spheres.Add(new Sphere(Convert.ToDouble(s1[0]), Convert.ToDouble(s1[1]), Convert.ToDouble(s1[2]),
                    Convert.ToDouble(s1[3])));
                s = streamReader.ReadLine();
                int num = Convert.ToInt32(s);
                for (int i = 1; i <= num; i++)
                {
                    s = streamReader.ReadLine();
                    s1 = s.Trim().ToCharArray();
                    bool ok;
                    Sphere si = new Sphere(Convert.ToDouble(s1[0]), Convert.ToDouble(s1[1]), Convert.ToDouble(s1[2]),
                        Convert.ToDouble(s1[3]));
                    foreach (var sphere in spheres.Where(x => x.Connected == false))
                    {
                        if (Math.Sqrt(Math.Pow(sphere.x - spheres[0].x, 2) + Math.Pow(sphere.y - spheres[0].y, 2) +
                                      Math.Pow(sphere.z - spheres[0].z, 2)) > si.r + sphere.r)
                        {
                            sphere.SetConnected(true);
                            si.SetConnected(true);
                        }
                    }

                    spheres.Add(si);
                }
            }
        }
    }
}