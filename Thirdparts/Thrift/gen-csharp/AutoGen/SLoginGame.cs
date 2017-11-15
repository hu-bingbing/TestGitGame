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
  public partial class SLoginGame : TBase
  {
    private bool _state;
    private string _error;
    private AutoGen.AccountData _account;

    public bool State
    {
      get
      {
        return _state;
      }
      set
      {
        __isset.state = true;
        this._state = value;
      }
    }

    public string Error
    {
      get
      {
        return _error;
      }
      set
      {
        __isset.error = true;
        this._error = value;
      }
    }

    public AutoGen.AccountData Account
    {
      get
      {
        return _account;
      }
      set
      {
        __isset.account = true;
        this._account = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool state;
      public bool error;
      public bool account;
    }

    public SLoginGame() {
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
              if (field.Type == TType.Bool) {
                State = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 20:
              if (field.Type == TType.String) {
                Error = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 30:
              if (field.Type == TType.Struct) {
                Account = new AutoGen.AccountData();
                Account.Read(iprot);
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
        TStruct struc = new TStruct("SLoginGame");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.state) {
          field.Name = "state";
          field.Type = TType.Bool;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(State);
          oprot.WriteFieldEnd();
        }
        if (Error != null && __isset.error) {
          field.Name = "error";
          field.Type = TType.String;
          field.ID = 20;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Error);
          oprot.WriteFieldEnd();
        }
        if (Account != null && __isset.account) {
          field.Name = "account";
          field.Type = TType.Struct;
          field.ID = 30;
          oprot.WriteFieldBegin(field);
          Account.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("SLoginGame(");
      bool __first = true;
      if (__isset.state) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("State: ");
        __sb.Append(State);
      }
      if (Error != null && __isset.error) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Error: ");
        __sb.Append(Error);
      }
      if (Account != null && __isset.account) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Account: ");
        __sb.Append(Account== null ? "<null>" : Account.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
