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
  public partial class SCDelFriend : TBase
  {
    private int _result;
    private Protol.PlayerData _friendInfo;

    public int Result
    {
      get
      {
        return _result;
      }
      set
      {
        __isset.result = true;
        this._result = value;
      }
    }

    public Protol.PlayerData FriendInfo
    {
      get
      {
        return _friendInfo;
      }
      set
      {
        __isset.friendInfo = true;
        this._friendInfo = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool result;
      public bool friendInfo;
    }

    public SCDelFriend() {
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
                Result = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.Struct) {
                FriendInfo = new Protol.PlayerData();
                FriendInfo.Read(iprot);
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
        TStruct struc = new TStruct("SCDelFriend");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.result) {
          field.Name = "result";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Result);
          oprot.WriteFieldEnd();
        }
        if (FriendInfo != null && __isset.friendInfo) {
          field.Name = "friendInfo";
          field.Type = TType.Struct;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          FriendInfo.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("SCDelFriend(");
      bool __first = true;
      if (__isset.result) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Result: ");
        __sb.Append(Result);
      }
      if (FriendInfo != null && __isset.friendInfo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FriendInfo: ");
        __sb.Append(FriendInfo== null ? "<null>" : FriendInfo.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
