using System.Windows;
using System.Windows.Media;

namespace InfiniteScrollViewer
{
    public interface ITransformHolder
    {
        ScaleTransform ScaleMatrix { get; }

        TranslateTransform TranslateMatrix { get; }
    }

    public static class TransformHolderExtensions
    {
        private static Point TransformPoint(this ITransformHolder self, double x, double y)
        {
            return new Point(
                (x - self.TranslateMatrix.X) / self.ScaleMatrix.ScaleX,
                (y - self.TranslateMatrix.Y) / self.ScaleMatrix.ScaleY);
        }

        /// <summary>
        /// 中心を指定して拡縮を行う
        /// </summary>
        /// <param name="self"></param>
        /// <param name="scale"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        public static void Scale(this ITransformHolder self, double scale, double centerX, double centerY)
        {
            var d0 = self.TransformPoint(centerX, centerY);

            self.ScaleMatrix.ScaleX = scale;
            self.ScaleMatrix.ScaleY = scale;

            var d1 = self.TransformPoint(centerX, centerY);

            var diff = d1 - d0;

            self.TranslateMatrix.X += diff.X * scale;
            self.TranslateMatrix.Y += diff.Y * scale;
        }

        public static void Translate(this ITransformHolder self, double offsetX , double offsetY)
        {
            self.TranslateMatrix.X += offsetX ;
            self.TranslateMatrix.Y += offsetY ;
        }
        public static void SetTranslate(this ITransformHolder self, double offsetX, double offsetY)
        {
            self.TranslateMatrix.X = offsetX;
            self.TranslateMatrix.Y = offsetY;
        }

        public static void SetTranslateX(this ITransformHolder self, double offsetX)
        {
            self.TranslateMatrix.X = offsetX;
        }
        public static void SetTranslateY(this ITransformHolder self, double offsetY)
        {
            self.TranslateMatrix.Y = offsetY;
        }
        public static void TranslateX(this ITransformHolder self, double offsetX)
        {
            self.TranslateMatrix.X += offsetX;
        }
        public static void TranslateY(this ITransformHolder self, double offsetY)
        {
            self.TranslateMatrix.Y += offsetY;
        }
        public static Point GetTranslateToPosition(this ITransformHolder self)
        {
            return new Point(self.TranslateMatrix.X, self.TranslateMatrix.Y);
        }
    }
}
