using System.Windows.Media.Media3D;

namespace GraphPlot.Utils.Constants
{
    internal static class SceneConstants
    {
        public static Point3D DefaultCameraPosition { get; private set; } = new Point3D(0, 2, 5);
        public static Vector3D DefaultCameraDirection { get; private set; } = new Vector3D(0, -0.4, -1);
    }
}
