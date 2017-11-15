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
  public partial class CmdTakeDamage : TBase
  {
    private int _amount;
    private int _causer;

    public int Amount
    {
      get
      {
        return _amount;
      }
      set
      {
        __isset.amount = true;
        this._amount = value;
      }
    }

    public int Causer
    {
      get
      {
        return _causer;
      }
      set
      {
        __isset.causer = true;
        this._causer = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool amount;
      public bool causer;
    }

    public CmdTakeDamage() {
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
                Amount = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.I32) {
                Causer = iprot.ReadI32();
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
        TStruct struc = new TStruct("CmdTakeDamage");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.amount) {
          field.Name = "amount";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Amount);
          oprot.WriteFieldEnd();
        }
        if (__isset.causer) {
          field.Name = "causer";
          field.Type = TType.I32;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Causer);
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
      StringBuilder __sb = new StringBuilder("CmdTakeDamage(");
      bool __first = true;
      if (__isset.amount) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Amount: ");
        __sb.Append(Amount);
      }
      if (__isset.causer) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Causer: ");
        __sb.Append(Causer);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
