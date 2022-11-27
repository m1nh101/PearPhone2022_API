using Core.Exceptions;
using Shared.Bases;

namespace Core.Entities.Phones;

public class PhoneDetail : Entity
{
  private PhoneDetail() { }

  public PhoneDetail(
      string battery,
      string screen,
      string os,
      int ram,
      string charger,
      string camera,
      string audio,
      string security,
      string connection)
  {
    if(string.IsNullOrEmpty(battery))
      throw new ArgumentNullException(nameof(battery), "Thông tin PIN không được để trống");

    if(string.IsNullOrEmpty(screen))
      throw new ArgumentNullException(nameof(screen), "Thông tin màn hình không được trống");

    if(string.IsNullOrEmpty(os))
      throw new ArgumentNullException(nameof(os), "Thông tin hệ điều hành không được trống");

    if(string.IsNullOrEmpty(charger))
      throw new ArgumentNullException(nameof(charger), "Thông tin sạc không được để trống");

    if(ram < 0)
        throw new InvalidNumberException( "Ram không thể nhỏ hơn không");

    if(string.IsNullOrEmpty(camera))
      throw new ArgumentNullException(nameof(camera), "Thông tin camera không được để trống");

    if(string.IsNullOrEmpty(audio))
      throw new ArgumentNullException(nameof(audio), "Thông tin loa không được để trống");

    if(string.IsNullOrEmpty(security))
      throw new ArgumentNullException(nameof(security), "Thông tin mở khóa không được để trống");

    if(string.IsNullOrEmpty(connection))
      throw new ArgumentNullException(nameof(connection), "Thông tin kết nối không được để trống");

    Battery = battery;
    Screen = screen;
    OS = os;
    RAM = ram;
    Charger = charger;
    Camera = camera;
    Audio = audio;
    Security = security;
    Connection = connection;
  }
  /// <summary>
  /// get or set battery of phone
  /// </summary>
  public string Battery { get; private set; } = string.Empty;

  /// <summary>
  /// get or set screen information of phone
  /// </summary>
  public string Screen { get; private set; } = string.Empty;

  /// <summary>
  /// get or set operating system and current version that installed in the phone
  /// </summary>
  public string OS { get; private set; } = string.Empty;

  /// <summary>
  /// get or set charge information of phone
  /// </summary>
  public string Charger { get; private set; } = string.Empty;

  /// <summary>
  /// get or set CPU of phone
  /// </summary>
  public string CPU { get; private set; } = string.Empty;

  /// <summary>
  /// get or set memory of phone
  /// </summary>
  public int RAM { get; private set; }

  /// <summary>
  /// get or set camera information phone use
  /// </summary>
  public string Camera { get; private set; } = string.Empty;

  /// <summary>
  /// get or set audio information
  /// </summary>
  public string Audio { get; private set; } = string.Empty;

  /// <summary>
  /// get or set security feature of phone
  /// </summary>
  public string? Security { get; private set; } = string.Empty;

  /// <summary>
  /// get or set connection types phone support
  /// </summary>
  public string Connection { get; private set; } = string.Empty;

  //navigation and foreign key
  public virtual ICollection<Stock> Stocks { get; private set; } = null!;

  public void Update(PhoneDetail phoneDetail)
  {
    Battery = phoneDetail.Battery;
    Screen = phoneDetail.Screen;
    OS = phoneDetail.OS;
    Charger = phoneDetail.Charger;
    CPU = phoneDetail.CPU;
    RAM = phoneDetail.RAM;
    Camera = phoneDetail.Camera;
    Audio = phoneDetail.Audio;
    Security = phoneDetail.Security;
    Connection = phoneDetail.Connection;
  }
}