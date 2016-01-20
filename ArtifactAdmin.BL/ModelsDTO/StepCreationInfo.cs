using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    using System.Drawing;

    /// <summary>
    /// Визначає набір даних для створення кроку.
    /// </summary>
    public class StepCreationInfo
    {
        /// <summary>
        /// Айдішка шаблону кроку.
        /// </summary>
        public int TemplateId { get; set; }
        /// <summary>
        /// Координати кроку.
        /// </summary>
        public Point Coordinates { get; set; }
        /// <summary>
        /// Визначає чи ключ має бути ключовим чи ні.
        /// </summary>
        public bool IsKey { get; set; }
    }
}