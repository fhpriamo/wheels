using System;

namespace Wheels
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			#if true

			var a = new BWheel(24);
			var b = new BWheel(72);
			var c = new BWheel(36);
			var d = new BWheel(108);
			var e = new BWheel(12);
			var f = new BWheel(48);
			var g = new BWheel(16);

			a.Attach(b);
			b.Couples(c);
			c.Attach(d);
			b.Attach(e);
			b.Attach(e);
			e.Attach(b);
			e.Attach(f);
			e.Attach(g);

			a.Spin(18d);

			Console.WriteLine($"Gear a RPM: {a.Rpm}");
			Console.WriteLine($"Gear b RPM: {b.Rpm}");
			Console.WriteLine($"Gear c RPM: {c.Rpm}");
			Console.WriteLine($"Gear d RPM: {d.Rpm}");
			Console.WriteLine($"Gear e RPM: {e.Rpm}");
			Console.WriteLine($"Gear f RPM: {f.Rpm}");
			Console.WriteLine($"Gear g RPM: {g.Rpm}");

			#endif
		}
	}
}
