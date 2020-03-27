using csjvm.classdefination.common.reader;

namespace csjvm.classdefination.common.annotation
{
    /// <summary>
    /// annotation {
    ///    u2 type_index;
    ///    u2 num_element_value_pairs;
    ///    {   u2            element_name_index;
    ///        element_value value;
    ///    } element_value_pairs[num_element_value_pairs];
    ///}
    /// </summary>
    public class Annotation : IReadable<Annotation>
    {
        private ushort TypeIndex { set; get; }
        private ushort NumElementValuePairs { set; get; }
        private ElementValuePair[] ElementValuePairs { set; get; }

        public Annotation Read(ClassData classData)
        {
            this.TypeIndex = classData.ReadUint16();
            this.NumElementValuePairs = classData.ReadUint16();
            this.ElementValuePairs =
                new ElementValuePairReader(classData).ReadElementValuePairs(this.NumElementValuePairs);
            return this;
        }
    }


    /// <summary>
    /// annotation {
    ///    u2 type_index;
    ///    u2 num_element_value_pairs;
    ///    {   u2            element_name_index;
    ///        element_value value;
    ///    } element_value_pairs[num_element_value_pairs];
    ///}
    /// </summary>
    public class ElementValuePair : IReadable<ElementValuePair>
    {
        private ushort ElementNameIndex { set; get; }
        private ElementValue ElementValue { set; get; }

        public ElementValuePair Read(ClassData classData)
        {
            this.ElementNameIndex = classData.ReadUint16();
            this.ElementValue = new ElementValue().Read(classData);

            return this;
        }
    }

    /// <summary>
    /// element_value {
    ///    u1 tag;
    ///    union {
    ///        u2 const_value_index;
    ///        {   u2 type_name_index;
    ///            u2 const_name_index;
    ///        } enum_const_value;
    ///        u2 class_info_index;
    ///        annotation annotation_value;
    ///        {   u2            num_values;
    ///            element_value values[num_values];
    ///        } array_value;
    ///    } value;
    ///}
    /// </summary>
    public class ElementValue : IReadable<ElementValue>
    {
        private byte Tag { set; get; }
        private Value Value { set; get; }

        public ElementValue Read(ClassData classData)
        {
            this.Tag = classData.ReadUint8();
            this.Value = new Value().Read(classData);

            return this;
        }
    }

    public class Value : IReadable<Value>
    {
        private ushort ConstValueIndex { set; get; }
        private EnumConstValue EnumConstValue { set; get; }
        private Annotation AnnotationValue { set; get; }
        private ArrayValue ArrayValue { set; get; }

        public Value Read(ClassData classData)
        {
            this.ConstValueIndex = classData.ReadUint16();
            this.EnumConstValue = new EnumConstValue().Read(classData);
            this.AnnotationValue = new Annotation().Read(classData);
            this.ArrayValue = new ArrayValue().Read(classData);

            return this;
        }
    }

    public class EnumConstValue : IReadable<EnumConstValue>
    {
        private ushort TypeNameIndex { set; get; }
        private ushort ConstNameIndex { set; get; }

        public EnumConstValue Read(ClassData classData)
        {
            this.TypeNameIndex = classData.ReadUint16();
            this.ConstNameIndex = classData.ReadUint16();
            return this;
        }
    }

    public class ArrayValue : IReadable<ArrayValue>
    {
        private ushort NumValues { set; get; }
        private ElementValue[] Values { set; get; }

        public ArrayValue Read(ClassData classData)
        {
            this.NumValues = classData.ReadUint16();
            var values = new ElementValue [this.NumValues];
            for (var i = 0; i < this.NumValues; i++)
            {
                values[i] = new ElementValue().Read(classData);
            }

            this.Values = values;

            return this;
        }
    }
}