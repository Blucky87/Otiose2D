using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Nez;

namespace Otiose2D.Input
{
    public static class Utility
    {
        public const float Epsilon = 1.0e-7f;
    
        public static bool EntityIsCulledOnCurrentCamera(Entity entity) {
            return true;
            //return (Camera.current.cullingMask & (1 << gameObject.layer)) == 0;
        }




        public static float ApplyDeadZone(float value, float lowerDeadZone, float upperDeadZone)
        {
            if (value < 0.0f)
            {
                if (value > -lowerDeadZone)
                {
                    return 0.0f;
                }

                if (value < -upperDeadZone)
                {
                    return -1.0f;
                }

                return (value + lowerDeadZone) / (upperDeadZone - lowerDeadZone);
            }
            else
            {
                if (value < lowerDeadZone)
                {
                    return 0.0f;
                }

                if (value > upperDeadZone)
                {
                    return 1.0f;
                }

                return (value - lowerDeadZone) / (upperDeadZone - lowerDeadZone);
            }
        }


        public static Vector2 ApplyCircularDeadZone(Vector2 v, float lowerDeadZone, float upperDeadZone) {
            
            var magnitude = Mathf.inverseLerp(lowerDeadZone, upperDeadZone, v.Length());
            v.Normalize();
            return v * magnitude;
        }


        public static Vector2 ApplyCircularDeadZone(float x, float y, float lowerDeadZone, float upperDeadZone)
        {
            return ApplyCircularDeadZone(new Vector2(x, y), lowerDeadZone, upperDeadZone);
        }




        public static float ApplySnapping(float value, float threshold)
        {
            if (value < -threshold)
            {
                return -1.0f;
            }

            if (value > threshold)
            {
                return 1.0f;
            }

            return 0.0f;
        }


        internal static bool TargetIsButton(InputControlType target)
        {
            return (target >= InputControlType.Action1 && target <= InputControlType.Action4) || (target >= InputControlType.Button0 && target <= InputControlType.Button19);
        }


        internal static bool TargetIsStandard(InputControlType target)
        {
            return target >= InputControlType.LeftStickUp && target <= InputControlType.RightBumper;
        }


#if NETFX_CORE
		public static async Task<string> Async_ReadFromFile( string path )
		{
			string name = Path.GetFileName( path );
			string folderPath = Path.GetDirectoryName( path );
			StorageFolder folder = await StorageFolder.GetFolderFromPathAsync( folderPath );
			StorageFile file = await folder.GetFileAsync( name );
			return await FileIO.ReadTextAsync( file );
		}

		public static async Task Async_WriteToFile( string path, string data )
		{
			string name = Path.GetFileName( path );
			string folderPath = Path.GetDirectoryName( path );
			StorageFolder folder = await StorageFolder.GetFolderFromPathAsync( folderPath );
			StorageFile file = await folder.CreateFileAsync( name, CreationCollisionOption.ReplaceExisting );
		    await FileIO.WriteTextAsync( file, data );
		}
#endif


        public static string ReadFromFile(string path)
        {
#if NETFX_CORE
			return Async_ReadFromFile( path ).Result;
#else
            var streamReader = new StreamReader(path);
            var data = streamReader.ReadToEnd();
            streamReader.Close();
            return data;
#endif
        }


        public static void WriteToFile(string path, string data)
        {
#if NETFX_CORE
			Async_WriteToFile( path, data ).Wait();
#else
            var streamWriter = new StreamWriter(path);
            streamWriter.Write(data);
            streamWriter.Flush();
            streamWriter.Close();
#endif
        }


        public static float Abs(float value)
        {
            return value < 0.0f ? -value : value;
        }


        public static bool Approximately(float value1, float value2)
        {
            var delta = value1 - value2;
            return (delta >= -Epsilon) && (delta <= Epsilon);
        }


        public static bool IsNotZero(float value)
        {
            return (value < -Epsilon) || (value > Epsilon);
        }


        public static bool IsZero(float value)
        {
            return (value >= -Epsilon) && (value <= Epsilon);
        }


        public static bool AbsoluteIsOverThreshold(float value, float threshold)
        {
            return (value < -threshold) || (value > threshold);
        }


        public static float NormalizeAngle(float angle)
        {
            while (angle < 0.0f)
            {
                angle += 360.0f;
            }

            while (angle > 360.0f)
            {
                angle -= 360.0f;
            }

            return angle;
        }


        public static float VectorToAngle(Vector2 vector)
        {
            if (Utility.IsZero(vector.X) && Utility.IsZero(vector.Y))
            {
                return 0.0f;
            }
            return Utility.NormalizeAngle(Mathf.atan2(vector.X, vector.Y) * 180.0f/(float)Math.PI);
        }


        public static float Min(float v0, float v1, float v2, float v3)
        {
            var r0 = (v0 >= v1) ? v1 : v0;
            var r1 = (v2 >= v3) ? v3 : v2;
            return (r0 >= r1) ? r1 : r0;
        }


        public static float Max(float v0, float v1, float v2, float v3)
        {
            var r0 = (v0 <= v1) ? v1 : v0;
            var r1 = (v2 <= v3) ? v3 : v2;
            return (r0 <= r1) ? r1 : r0;
        }


        internal static float ValueFromSides(float negativeSide, float positiveSide)
        {
            var nsv = Utility.Abs(negativeSide);
            var psv = Utility.Abs(positiveSide);

            if (Utility.Approximately(nsv, psv))
            {
                return 0.0f;
            }

            return nsv > psv ? -nsv : psv;
        }


        internal static float ValueFromSides(float negativeSide, float positiveSide, bool invertSides)
        {
            if (invertSides)
            {
                return ValueFromSides(positiveSide, negativeSide);
            }
            else
            {
                return ValueFromSides(negativeSide, positiveSide);
            }
        }


        internal static bool Is32Bit
        {
            get
            {
                return IntPtr.Size == 4;
            }
        }


        internal static bool Is64Bit
        {
            get
            {
                return IntPtr.Size == 8;
            }
        }

    }
}
