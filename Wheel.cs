using System;
using System.Collections.Generic;

namespace Wheels
{
	/// <summary>
	/// A Wheel.
	/// </summary>
	public class Wheel
	{
		/// <summary>
		/// List of wheels driven by this wheel instance.
		/// </summary>
		private List<Wheel> _drivenWheels = new List<Wheel>();

		/// <summary>
		/// List of wheels coupled in this wheel instance.
		/// </summary>
		private List<Wheel> _coupledWheels = new List<Wheel>();

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
		public Wheel (int cogs)
		{
			Cogs = cogs;
		}

		/// <summary>
		/// Drives another wheel.
		/// </summary>
		/// <param name="w">Another wheel.</param>
		public void Drives(Wheel w)
		{
			_drivenWheels.Add (w);
		}

		/// <summary>
		/// Couples a wheel.
		/// </summary>
		/// <param name="w">Another wheel.</param>
		public void Couples(Wheel w)
		{
			_coupledWheels.Add (w);
		}

		/// <summary>
		/// Spins the wheel.
		/// </summary>
		/// <param name="rpm">Rpm.</param>
		public void Spin(double rpm)
		{
			Rpm = rpm;

			// Spin all the driven wheels.
			foreach (Wheel dw in _drivenWheels) {
				dw.Spin (Rpm / (dw.Cogs / Convert.ToDouble(Cogs)));
			}

			// Spin all the coupled wheels.
			foreach (Wheel cw in _coupledWheels) {
				cw.Spin (Rpm);
			}
		}
	}
}
