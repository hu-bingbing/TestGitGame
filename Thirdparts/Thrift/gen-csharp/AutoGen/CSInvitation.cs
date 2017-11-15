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
  public partial class CSInvitation : TBase
  {
    private string _nickname;

    public string Nickname
    {
      get
      {
        return _nickname;
      }
      set
      {
        __isset.nickname = true;
        this._nickname = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool nickname;
    }

    public CSInvitation() {
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
              if (field.Type == TType.String) {
                Nickname = iprot.ReadString();
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
        TStruct struc = new TStruct("CSInvitation");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Nickname != null && __isset.nickname) {
          field.Name = "nickname";
          field.Type = TType.String;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Nickname);
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
      StringBuilder __sb = new StringBuilder("CSInvitation(");
      bool __first = true;
      if (Nickname != null && __isset.nickname) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Nickname: ");
        __sb.Append(Nickname);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
