using System;
namespace FreeCourse.Services.Catalog.Settings
{
    internal interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }

        public string CourseCollectionName { get; set; }

        public string FeatureCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

    }
}
