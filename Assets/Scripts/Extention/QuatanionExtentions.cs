using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

/// <summary>
///  QuaternionExtensions
/// 
/// </summary>
public static class QuaternionExtensions
{
	public static Quaternion WithEuler(this Quaternion org, float? x = null, float? y = null, float? z = null)
	{
		Vector3 euler = org.eulerAngles;
		return Quaternion.Euler(x ?? euler.x , y ?? euler.y, z ?? euler.z );
	}
	
	public static Quaternion AddEuler(this Quaternion org, float? x = null, float? y = null, float? z = null)
	{
		Vector3 euler = org.eulerAngles;
		return Quaternion.Euler((x!=null) ? euler.x + (float)x : euler.x  , (y!=null) ? euler.y + (float)y : euler.y, (z!=null) ? euler.z + (float)z : euler.z);
	}
	
	public static bool IsUpper(this Quaternion org)
	{
		Vector3 euler = org.eulerAngles;
		float z = (euler.z > 180) ? euler.z - 360.0f : euler.z ; 
		
		if (Mathf.Abs(z) <= 90) return true;

		return false;
	}
	
	public static Quaternion Pow(this Quaternion input, float power)
	{
		float inputMagnitude = input.Magnitude();
		Vector3 nHat = new Vector3(input.x, input.y, input.z).normalized;
		Quaternion vectorBit = new Quaternion(nHat.x, nHat.y, nHat.z, 0)
			.ScalarMultiply(power * Mathf.Acos(input.w / inputMagnitude))
			.Exp();
		return vectorBit.ScalarMultiply(Mathf.Pow(inputMagnitude, power));
	}
 
	public static Quaternion Exp(this Quaternion input)
	{
		float inputA = input.w;
		Vector3 inputV = new Vector3(input.x, input.y, input.z);
		float outputA = Mathf.Exp(inputA) * Mathf.Cos(inputV.magnitude);
		Vector3 outputV = Mathf.Exp(inputA) * (inputV.normalized * Mathf.Sin(inputV.magnitude));
		return new Quaternion(outputV.x, outputV.y, outputV.z, outputA);
	}
 
	public static float Magnitude(this Quaternion input)
	{
		return Mathf.Sqrt(input.x * input.x + input.y * input.y + input.z * input.z + input.w * input.w);
	}
 
	public static Quaternion ScalarMultiply(this Quaternion input, float scalar)
	{
		return new Quaternion(input.x * scalar, input.y * scalar, input.z * scalar, input.w * scalar);
	}
}