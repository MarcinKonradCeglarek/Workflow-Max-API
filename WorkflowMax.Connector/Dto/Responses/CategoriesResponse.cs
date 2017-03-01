namespace WorkflowMax.Connector.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using WorkflowMax.Connector.Dto.Abstract;

    [Serializable, XmlRoot("Response")]
    public class CategoriesResponse : WorkfloMaxResponse
    {
        [XmlArray("TeamMembers")]
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        [XmlElement(ElementName = "ID")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}