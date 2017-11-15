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

namespace Protol
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SCExitGame : TBase
  {
    private long _userId;

    public long UserId
    {
      get
      {
        return _userId;
      }
      set
      {
        __isset.userId = true;
        this._userId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool userId;
    }

    public SCExitGame() {
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
              if (field.Type == TType.I64) {
                UserId = iprot.ReadI64();
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
        TStruct struc = new TStruct("SCExitGame");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.userId) {
          field.Name = "userId";
          field.Type = TType.I64;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(UserId);
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
      StringBuilder __sb = new StringBuilder("SCExitGame(");
      bool __first = true;
      if (__isset.userId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UserId: ");
        __sb.Append(UserId);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
