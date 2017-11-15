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

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ItemConfigTable : TBase
  {
    private Dictionary<int, ItemConfig> _itemConfigMap;

    public Dictionary<int, ItemConfig> ItemConfigMap
    {
      get
      {
        return _itemConfigMap;
      }
      set
      {
        __isset.itemConfigMap = true;
        this._itemConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool itemConfigMap;
    }

    public ItemConfigTable() {
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
              if (field.Type == TType.Map) {
                {
                  ItemConfigMap = new Dictionary<int, ItemConfig>();
                  TMap _map24 = iprot.ReadMapBegin();
                  for( int _i25 = 0; _i25 < _map24.Count; ++_i25)
                  {
                    int _key26;
                    ItemConfig _val27;
                    _key26 = iprot.ReadI32();
                    _val27 = new ItemConfig();
                    _val27.Read(iprot);
                    ItemConfigMap[_key26] = _val27;
                  }
                  iprot.ReadMapEnd();
                }
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
        TStruct struc = new TStruct("ItemConfigTable");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (ItemConfigMap != null && __isset.itemConfigMap) {
          field.Name = "itemConfigMap";
          field.Type = TType.Map;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, ItemConfigMap.Count));
            foreach (int _iter28 in ItemConfigMap.Keys)
            {
              oprot.WriteI32(_iter28);
              ItemConfigMap[_iter28].Write(oprot);
            }
            oprot.WriteMapEnd();
          }
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
      StringBuilder __sb = new StringBuilder("ItemConfigTable(");
      bool __first = true;
      if (ItemConfigMap != null && __isset.itemConfigMap) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ItemConfigMap: ");
        __sb.Append(ItemConfigMap);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
