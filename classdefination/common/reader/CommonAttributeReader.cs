using csjvm.classdefination.common.attribute;
using csjvm.classdefination.constantpool;
using csjvm.error;

namespace csjvm.classdefination.common.reader
{
    /// <summary>
    /// 描述：Method,Field属性读取器
    /// </summary>
    public class CommonAttributeReader
    {
        private readonly ClassData _classData;
        private readonly ConstantPool _constantPool;

        public CommonAttributeReader(ClassData classData, ConstantPool constantPool)
        {
            this._classData = classData;
            this._constantPool = constantPool;
        }
        

        public AttributeInfo [] ReadAttributeInfos(uint count)
        {
            var attributes = new AttributeInfo[count];
            for (var i = 0; i < count; i++)
            {
                var attributeNameIndex = _classData.ReadUint16WithoutSub();

                if (attributeNameIndex == 0) return null;
                var attributeName = _constantPool.GetUtf8(attributeNameIndex);

                IAttribute attribute = attributeName switch
                {
                    "ConstantValue" => new ConstantValueAttribute(),
                    "Code" => new CodeAttribute(),
                    "StackMapTable" => new StackMapTableAttribute(),
                    "Exceptions" => new ExceptionsAttribute(),
                    "InnerClasses" => new InnerClassesAttribute(),
                    "EnclosingMethod" => new EnclosingMethodAttribute(),
                    "Synthetic" => new SyntheticAttribute(),
                    "Signature" => new SignatureAttribute(),
                    "SourceFile" => new SourceFileAttribute(),
                    "SourceDebugExtension" => new SourceDebugExtensionAttribute(),
                    "LineNumberTable" => new LineNumberTableAttribute(),
                    "LocalVariableTable" => new LocalVariableTableAttribute(),
                    "LocalVariableTypeTable" => new LocalVariableTypeTableAttribute(),
                    "Deprecated" => new DeprecatedAttribute(),
                    "RuntimeVisibleAnnotations" => new RuntimeVisibleAnnotationsAttribute(),
                    "RuntimeInvisibleAnnotations" => new RuntimeInvisibleAnnotationsAttribute(),
                    "RuntimeVisibleParameterAnnotations" => new RuntimeVisibleParameterAnnotationsAttribute(),
                    "RuntimeInvisibleParameterAnnotations" => new RuntimeInvisibleParameterAnnotationsAttribute(),
                    "RuntimeVisibleTypeAnnotations" => new RuntimeVisibleTypeAnnotationsAttribute(),
                    "RuntimeInvisibleTypeAnnotations" => new RuntimeInvisibleTypeAnnotationsAttribute(),
                    "AnnotationDefault" => new AnnotationDefaultAttribute(),
                    "BootstrapMethods" => new BootstrapMethodsAttribute(),
                    "MethodParameters" => new MethodParametersAttribute(),
                    _ => throw new ClassFormatError("Can not find attribute :" + attributeName)
                };

                attribute.ReadWithExtends(_classData, _constantPool);

                attributes[i] = (AttributeInfo) attribute;
            }

            return attributes;
        }
    }
}