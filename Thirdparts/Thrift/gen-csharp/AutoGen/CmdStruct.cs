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
  public partial class CmdStruct : TBase
  {
    private int _type;
    private int _argv1;
    private int _argv2;

    public int Type
    {
      get
      {
        return _type;
      }
      set
      {
        __isset.type = true;
        this._type = value;
      }
    }

    public int Argv1
    {
      get
      {
        return _argv1;
      }
      set
      {
        __isset.argv1 = true;
        this._argv1 = value;
      }
    }

    public int Argv2
    {
      get
      {
        return _argv2;
      }
      set
      {
        __isset.argv2 = true;
        this._argv2 = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool type;
      public bool argv1;
      public bool argv2;
    }

    public CmdStruct() {
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
                Type = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.I32) {
                Argv1 = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 30:
              if (field.Type == TType.I32) {
                Argv2 = iprot.ReadI32();
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
        TStruct struc = new TStruct("CmdStruct");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.type) {
          field.Name = "type";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Type);
          oprot.WriteFieldEnd();
        }
        if (__isset.argv1) {
          field.Name = "argv1";
          field.Type = TType.I32;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Argv1);
          oprot.WriteFieldEnd();
        }
        if (__isset.argv2) {
          field.Name = "argv2";
          field.Type = TType.I32;
          field.ID = 30;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Argv2);
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
      StringBuilder __sb = new StringBuilder("CmdStruct(");
      bool __first = true;
      if (__isset.type) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Type: ");
        __sb.Append(Type);
      }
      if (__isset.argv1) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Argv1: ");
        __sb.Append(Argv1);
      }
      if (__isset.argv2) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Argv2: ");
        __sb.Append(Argv2);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
