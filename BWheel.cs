using System;
using System.Collections.Generic;

namespace Wheels
{
	/// <summary>
	/// A Wheel.
	/// </summary>
	public class BWheel
	{
		/// <summary>
		/// List of wheels driven by this wheel instance.
		/// </summary>
		private HashSet<BWheel> _attached = new HashSet<BWheel>();

		/// <summary>
		/// List of wheels coupled in this wheel instance.
		/// </summary>
		private HashSet<BWheel> _coupled = new HashSet<BWheel>();
	
		/// <summary>
		/// Gets the number of cogs on the wheel.
		/// </summary>
		/// <value>Number of cogs on the wheel.</value>
		public int Cogs { get; }

		/// <summary>
		/// Gets or sets (protected) the RPM of the wheel.
		/// RPM - Rotations Per Minute
		/// </summary>
		/// <value>Rpm.</value>
		public double Rpm { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Wheels.Wheel"/> class.
		/// </summary>
		/// <param name="cogs">Number of cogs.</param>
		public BWheel (int cogs)
		{
			Cogs = cogs;
		}

		/// <summary>
		/// Drives another wheel.
		/// </summary>
		/// <param name="w">Another wheel.</param>
		public void Drives(BWheel w)
		{
			Attach(w);
		}

		public void Attach(BWheel w)
		{
			_attached.Add (w);
			w.Driven(this);

		}

		/// <summary>
		/// Couples a wheel.
		/// </summary>
		/// <param name="w">Another wheel.</param>
		public void Couples(BWheel w)
		{
			Couple(w);
		}

		public void Couple(BWheel w)
		{
			_coupled.Add (w);
			w.Coupled(this);

		}

		internal void Driven(BWheel w)
		{
			_attached.Add(w);
		}

		internal void Coupled(BWheel w)
		{
			_coupled.Add(w);
		}

		/// <summary>
		/// Spins the wheel.
		/// </summary>
		/// <param name="rpm">Rpm.</param>
		public void Spin(double rpm)
		{
			Spin(rpm, this);
		}

		internal void Spin(double rpm, BWheel sender)
		{
			Rpm = rpm;

			// Spin all the driven wheels.
			foreach (BWheel dw in _attached)
			{
				// Avoid calling spin on the sender.
				// If this clause didn't exist, this method would be
				// called recursevely until the callstack overflows.
				if (object.ReferenceEquals(sender, dw))
				{
					continue;
				}

				// Calculates the RPM of the attached wheel.
				dw.Spin (Rpm / (dw.Cogs / Convert.ToDouble(Cogs)), this);
			}

			// Spin all the coupled wheels.
			foreach (BWheel cw in _coupled)
			{
				// Avoid calling spin on the sender.
				// If this clause didn't exist, this method would be
				// called recursevely until the callstack overflows.
				if (object.ReferenceEquals(sender, cw))
				{
					continue;
				}

				// The rpm for coupled wheels is the same
				// across all coupled wheels.
				cw.Spin (Rpm, this);
			}
		}
	}
}