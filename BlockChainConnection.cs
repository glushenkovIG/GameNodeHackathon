using System;
using Com.Expload;

[Program]
class CarList {
    public byte[] heads = new byte[8];
    public byte[] bodies = new byte[8];
    public byte[] wheels = new byte[8];

    public void AddCar(byte head, byte body, byte wheel) {
        heads [head  / 8] |= (byte) (1 << (head  % 8));
        bodies[body  / 8] |= (byte) (1 << (body  % 8));
        wheels[wheel / 8] |= (byte) (1 << (wheel % 8));
    }
}

class IncDec {
    public Mapping<String, int> winCount = new Mapping<String, int>();
    public Mapping<String, int> loseCount = new Mapping<String, int>();
    public Mapping<String, CarList> cars = new Mapping<String, CarList>();

    public CarList GetCars(String addr) {
        return cars.getDefault(addr, new CarList());
    }

    public void AddCar(String addr, byte head, byte body, byte wheel) {
        CarList carlist = GetCars(addr);
        carlist.AddCar(head, body, wheel);
        cars.put(addr, carlist);
    }

    public void Fight(String a, String b) {
        winCount.put(a, winCount.getDefault(a, 0) + 1);
        loseCount.put(b, loseCount.getDefault(b, 0) + 1);
    }

    public int ShowWins(String a) {
        return winCount.getDefault(a, 0);
    }

    public int ShowLoses(String a) {
        return loseCount.getDefault(a, 0);
    }
}

class MainClass { public static void Main() {} }
