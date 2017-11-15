/**
 * Autogenerated by Thrift Compiler (@PACKAGE_VERSION@)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace AutoGen
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class CSQuickMatchClassType : TBase
  {
    private AutoGen.ClassType _classType;

    /// <summary>
    /// 
    /// <seealso cref="AutoGen.ClassType"/>
    /// </summary>
    public AutoGen.ClassType ClassType
    {
      get
      {
        return _classType;
      }
      set
      {
        __isset.classType = true;
        this._classType = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool classType;
    }

    public CSQuickMatchClassType() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 10:
              if (field.Type == TType.I32) {
                ClassType = (AutoGen.ClassType)iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("CSQuickMatchClassType");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.classType) {
          field.Name = "classType";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32((int)ClassType);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("CSQuickMatchClassType(");
      bool __first = true;
      if (__isset.classType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ClassType: ");
        __sb.Append(ClassType);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
