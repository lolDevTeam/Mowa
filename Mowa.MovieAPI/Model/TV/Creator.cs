// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Creator.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the Creator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.TV
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The creator.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class Creator
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Gets or sets the profile_ path.
        /// </summary>
        public string Profile_Path { get; set; }
    }
}
