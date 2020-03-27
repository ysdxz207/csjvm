using csjvm.classdefination.common.annotation;
using csjvm.classdefination.common.path;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.common.table;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// RuntimeVisibleTypeAnnotations_attribute {
    ///    u2              attribute_name_index;
    ///    u4              attribute_length;
    ///    u2              num_annotations;
    ///    type_annotation annotations[num_annotations];
    ///}
    /// </summary>
    public class RuntimeVisibleTypeAnnotationsAttribute : AttributeInfo
    {
        private ushort NumAnnotations { set; get; }
        private TypeAnnotation [] Annotations { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumAnnotations = classData.ReadUint16();
            this.Annotations = new TypeAnnotationReader(classData).ReadAnnotations(this.NumAnnotations);
        }
    }


    /// <summary>
    /// type_annotation {
    ///    u1 target_type;
    ///    union {
    ///        type_parameter_target;
    ///        supertype_target;
    ///        type_parameter_bound_target;
    ///        empty_target;
    ///        method_formal_parameter_target;
    ///        throws_target;
    ///        localvar_target;
    ///        catch_target;
    ///        offset_target;
    ///        type_argument_target;
    ///    } target_info;
    ///    type_path target_path;
    ///    u2        type_index;
    ///    u2        num_element_value_pairs;
    ///    {   u2            element_name_index;
    ///        element_value value;
    ///    } element_value_pairs[num_element_value_pairs];
    ///}
    /// </summary>
    public class TypeAnnotation : IReadable<TypeAnnotation>
    {
        private ushort TargetType { set; get; }
        private TargetInfo TargetInfo { set; get; }
        private TypePath TypePath { set; get; }
        private ushort TypeIndex { set; get; }
        private ushort NumElementValuePairs { set; get; }
        private ElementValuePair [] ElementValuePairs { set; get; }
        public TypeAnnotation Read(ClassData classData)
        {
            this.TargetType = classData.ReadUint16();
            this.TargetInfo = new TargetInfo().Read(classData);
            this.TypePath = new TypePath().Read(classData);
            this.TypeIndex = classData.ReadUint16();
            this.NumElementValuePairs = classData.ReadUint16();
            this.ElementValuePairs = new ElementValuePairReader(classData).ReadElementValuePairs(this.NumElementValuePairs);

            return this;
        }
    }

    /// <summary>
    /// type_path {
    ///    u1 path_length;
    ///    {   u1 type_path_kind;
    ///        u1 type_argument_index;
    ///    } path[path_length];
    ///}
    /// </summary>
    public class TypePath : IReadable<TypePath>
    {
        private byte PathLength { set; get; }
        private Path Path { set; get; }
        public TypePath Read(ClassData classData)
        {
            this.PathLength = classData.ReadUint8();
            this.Path = new Path().Read(classData);

            return this;
        }
    }


    public class TargetInfo : IReadable<TargetInfo>
    {
        private TypeParameterTarget TypeParameterTarget { set; get; }
        private SupertypeTarget SupertypeTarget { set; get; }
        private TypeParameterBoundTarget TypeParameterBoundTarget { set; get; }
        private EmptyTarget EmptyTarget { set; get; }
        private MethodFormalParameterTarget MethodFormalParameterTarget { set; get; }
        private ThrowsTarget ThrowsTarget { set; get; }
        private LocalvarTarget LocalvarTarget { set; get; }
        private CatchTarget CatchTarget { set; get; }
        private OffsetTarget OffsetTarget { set; get; }
        private TypeArgumentTarget TypeArgumentTarget { set; get; }


        public TargetInfo Read(ClassData classData)
        {
            this.TypeArgumentTarget = new TypeArgumentTarget().Read(classData);
            this.SupertypeTarget = new SupertypeTarget().Read(classData);
            this.TypeParameterBoundTarget = new TypeParameterBoundTarget().Read(classData);
            this.EmptyTarget = new EmptyTarget();
            this.MethodFormalParameterTarget = new MethodFormalParameterTarget().Read(classData);
            this.ThrowsTarget = new ThrowsTarget().Read(classData);
            this.LocalvarTarget = new LocalvarTarget().Read(classData);
            this.CatchTarget = new CatchTarget().Read(classData);
            this.OffsetTarget = new OffsetTarget().Read(classData);
            this.TypeArgumentTarget = new TypeArgumentTarget().Read(classData);

            return this;
        }
    }

    /// <summary>
    /// type_argument_target {
    ///    u2 offset;
    ///    u1 type_argument_index;
    /// }
    /// </summary>
    public class TypeArgumentTarget : IReadable<TypeArgumentTarget>
    {
        private ushort Offset { set; get; }
        private byte TypeArgumentIndex { set; get; }
        public TypeArgumentTarget Read(ClassData classData)
        {
            this.Offset = classData.ReadUint16();
            this.TypeArgumentIndex = classData.ReadUint8();

            return this;
        }
    }

    /// <summary>
    /// offset_target {
    ///    u2 offset;
    ///}
    /// </summary>
    public class OffsetTarget : IReadable<OffsetTarget>
    {
        private ushort Offset { set; get; }
        public OffsetTarget Read(ClassData classData)
        {
            this.Offset = classData.ReadUint16();

            return this;
        }
    }

    /// <summary>
    /// catch_target {
    ///    u2 exception_table_index;
    ///}
    /// </summary>
    public class CatchTarget : IReadable<CatchTarget>
    {
        private ushort ExceptionTableIndex { set; get; }
        public CatchTarget Read(ClassData classData)
        {
            this.ExceptionTableIndex = classData.ReadUint16();

            return this;
        }
    }

    /// <summary>
    /// localvar_target {
    ///    u2 table_length;
    ///    {   u2 start_pc;
    ///        u2 length;
    ///        u2 index;
    ///    } table[table_length];
    ///}
    /// </summary>
    public class LocalvarTarget : IReadable<LocalvarTarget>
    {
        private ushort TableLength { set; get; }
        private Table Table { set; get; }
        public LocalvarTarget Read(ClassData classData)
        {

            this.TableLength = classData.ReadUint16();
            this.Table = new Table().Read(classData);

            return this;
        }
    }

    /// <summary>
    /// throws_target {
    ///    u2 throws_type_index;
    ///}
    /// </summary>
    public class ThrowsTarget : IReadable<ThrowsTarget>
    {
        private byte ThrowsTypeIndex { set; get; }
        public ThrowsTarget Read(ClassData classData)
        {
            this.ThrowsTypeIndex = classData.ReadUint8();

            return this;
        }
    }

    /// <summary>
    /// formal_parameter_target {
    ///    u1 formal_parameter_index;
    ///}
    /// </summary>
    public class MethodFormalParameterTarget : IReadable<MethodFormalParameterTarget>
    {
        private byte FormalParameterIndex { set; get; }
        public MethodFormalParameterTarget Read(ClassData classData)
        {
            this.FormalParameterIndex = classData.ReadUint8();

            return this;
        }
    }

    /// <summary>
    /// empty_target {
    ///}
    /// </summary>
    public class EmptyTarget
    {
    }

    /// <summary>
    /// type_parameter_bound_target {
    ///    u1 type_parameter_index;
    ///    u1 bound_index;
    ///}
    /// </summary>
    public class TypeParameterBoundTarget : IReadable<TypeParameterBoundTarget>
    {
        private byte TypeParameterIndex { set; get; }
        private byte BoundIndex { set; get; }
        public TypeParameterBoundTarget Read(ClassData classData)
        {
            this.TypeParameterIndex = classData.ReadUint8();
            this.BoundIndex = classData.ReadUint8();

            return this;
        }
    }

    /// <summary>
    /// supertype_target {
    ///    u2 supertype_index;
    ///}
    /// </summary>
    public class SupertypeTarget : IReadable<SupertypeTarget>
    {
        private ushort SupertypeIndex { set; get; }
        public SupertypeTarget Read(ClassData classData)
        {
            this.SupertypeIndex = classData.ReadUint16();

            return this;
        }
    }

    /// <summary>
    /// type_parameter_target {
    ///    u1 type_parameter_index;
    ///}
    /// </summary>
    public class TypeParameterTarget : IReadable<TypeParameterTarget>
    {
        private byte TypeParameterIndex { set; get; }
        public TypeParameterTarget Read(ClassData classData)
        {
            this.TypeParameterIndex = classData.ReadUint8();

            return this;
        }
    }
}