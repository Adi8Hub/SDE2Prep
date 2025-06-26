// TODO: Class structure for Parking Lot system
//                      ## 🔧 1. **High-Level Requirements**

//      ### Functional:

// - Park a vehicle
// - Unpark a vehicle
// - Track free/occupied slots
// - Support different vehicle types (car, bike, truck, etc.)
// - Handle multiple floors

//  ### Non-functional:

// - Scalable and modular
// - Quick slot allocation
// - Easy maintainability

//                              ## 🏗️ 2. **Core Classes**


public enum VehicleType { Car, Bike, Truck }

public abstract class Vehicle
{
    public string LicensePlate { get; set; }
    public VehicleType Type { get; protected set; }
}

public class Car : Vehicle
{
    public Car(string plate) { LicensePlate = plate; Type = VehicleType.Car; }
}

public class Bike : Vehicle
{
    public Bike(string plate) { LicensePlate = plate; Type = VehicleType.Bike; }
}

public class Truck : Vehicle
{
    public Truck(string plate) { LicensePlate = plate; Type = VehicleType.Truck; }
}

public class ParkingSlot
{
    public int SlotNumber { get; }
    public VehicleType SlotType { get; }
    public bool IsOccupied { get; private set; }
    public Vehicle? ParkedVehicle { get; private set; }

    public ParkingSlot(int slotNumber, VehicleType type)
    {
        SlotNumber = slotNumber;
        SlotType = type;
        IsOccupied = false;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        if (IsOccupied || vehicle.Type != SlotType)
            return false;
        ParkedVehicle = vehicle;
        IsOccupied = true;
        return true;
    }

    public void UnparkVehicle()
    {
        IsOccupied = false;
        ParkedVehicle = null;
    }
}


//                  ## 🧱 3. **Floor and Parking Lot**


public class ParkingFloor
{
    public int FloorNumber { get; }
    private List<ParkingSlot> slots;

    public ParkingFloor(int number, List<ParkingSlot> slotList)
    {
        FloorNumber = number;
        slots = slotList;
    }

    public ParkingSlot? GetAvailableSlot(VehicleType type)
    {
        return slots.FirstOrDefault(s => s.SlotType == type && !s.IsOccupied);
    }

    public void DisplayFreeSlots()
    {
        foreach (var slot in slots.Where(s => !s.IsOccupied))
        {
            Console.WriteLine($"Floor {FloorNumber} - Slot {slot.SlotNumber} ({slot.SlotType})");
        }
    }
}


//              ## 🧠 4. **Slot Allocation Strategy**

// Use a simple strategy initially:

// Iterate floors → find the first available slot of the required type

//  (can be replaced with a heap/priority queue for optimal allocation later)


public class ParkingLot
{
    private List<ParkingFloor> floors;

    public ParkingLot(int floorCount, int slotsPerFloor)
    {
        floors = new List<ParkingFloor>();
        for (int f = 0; f < floorCount; f++)
        {
            var slots = new List<ParkingSlot>();
            for (int s = 0; s < slotsPerFloor; s++)
            {
                VehicleType type = (s % 3 == 0) ? VehicleType.Truck :
                                   (s % 3 == 1) ? VehicleType.Car :
                                                 VehicleType.Bike;
                slots.Add(new ParkingSlot(s + 1, type));
            }
            floors.Add(new ParkingFloor(f, slots));
        }
    }

    public bool Park(Vehicle vehicle)
    {
        foreach (var floor in floors)
        {
            var slot = floor.GetAvailableSlot(vehicle.Type);
            if (slot != null)
            {
                slot.ParkVehicle(vehicle);
                Console.WriteLine($"Vehicle parked at Floor {floor.FloorNumber}, Slot {slot.SlotNumber}");
                return true;
            }
        }
        Console.WriteLine("Parking Full");
        return false;
    }

    public void DisplayAvailability()
    {
        foreach (var floor in floors)
            floor.DisplayFreeSlots();
    }
}


//                          ## 🧪 5. **Example Usage**

//These lines will go at the top
var lot = new ParkingLot(2, 6); // 2 floors, 6 slots each

lot.Park(new Car("CAR-123"));
lot.Park(new Bike("BIKE-456"));
lot.Park(new Truck("TRUCK-789"));

lot.DisplayAvailability();

//                      ## 📈 6. **Scalability Enhancements**

// - 🔍 **Improve allocation strategy**: Use min-heaps per vehicle type.
// - 💾 **Persist state**: Use a DB for slot/vehicle info.
// - 🕸️ **Add API Layer**: For a web/mobile interface.
// - 📱 **Notifications**: SMS/alerts when full or after un-parking.
// - 📊 **Analytics**: Usage stats, peak hours.



//                          ## ✅ 7. **Summary Checklist**

// | Feature | Implemented |
// | --- | --- |
// | Class hierarchy | ✅ |
// | Slot allocation logic | ✅ |
// | Multi-floor support | ✅ |
// | Vehicle-type specific | ✅ |
// | Extendable architecture | ✅ |



// Let's expand and **clarify the full system design** of the **Parking Lot** with clear **scope**, **classes & relationships**, and **interactions/APIs**.



//                          ## ✅ 1. **Scope Definition**

//  ### Core Responsibilities:

// - **Vehicle Entry / Exit** management
// - **Slot allocation** based on vehicle type and floor
// - Support **multiple floors**
// - Support **multiple vehicle types** (Car, Bike, Truck)
// - Track **slot availability**



//                      ## 🧱 2. **Class Design Overview**

//  ### ✅ Entity Classes:

// | Class | Responsibility |
// | --- | --- |
// | `Vehicle` (abstract) | Base class for all vehicle types |
// | `Car`, `Bike`, `Truck` | Specific types of vehicles |
// | `ParkingSlot` | Represents an individual parking slot |
// | `ParkingFloor` | Represents one level of parking with multiple slots |
// | `ParkingLot` | Top-level class managing multiple floors |
// | `Ticket` *(optional)* | Represents a parking session (entry time, vehicle, slot) |
// | `ParkingManager` *(optional)* | Entry point managing park/unpark actions (API layer) |



//                      ## 🔗 3. **Class Relationships**


// [Vehicle] <|-- [Car]
// [Vehicle] <|-- [Bike]
// [Vehicle] <|-- [Truck]

// [ParkingLot] "1" --> "*" [ParkingFloor]
// [ParkingFloor] "1" --> "*" [ParkingSlot]

// [ParkingSlot] "1" --> "0..1" [Vehicle]  // optional when unoccupied

// [ParkingManager] --> [ParkingLot] (facade for APIs)



//                  ## 🔄 4. **Object Interactions: Flow**

//  ### ▶️ `Park Vehicle`

// 1. `ParkingManager.Park(vehicle)`
// 2. It calls `ParkingLot.GetAvailableSlot(vehicle.Type)`
// 3. Iterates floors to find a free slot of the required type.
// 4. If found, vehicle is parked and a `Ticket` is returned.

//  ### ⏹️ `Unpark Vehicle`

// 1. `ParkingManager.Unpark(licensePlate)`
// 2. Finds the floor & slot (via map or ticket)
// 3. Calls `ParkingSlot.UnparkVehicle()`
// 4. Frees the slot and returns success



//                  ## 🛠️ 5. **API Layer (ParkingManager)**

// This class acts like a REST controller or service layer.

public class ParkingManager
{
    private ParkingLot parkingLot;
    private Dictionary<string, (int floor, int slot)> vehicleSlotMap;

    public ParkingManager(ParkingLot lot)
    {
        parkingLot = lot;
        vehicleSlotMap = new Dictionary<string, (int, int)>();
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        var result = parkingLot.Park(vehicle, out int floor, out int slot);
        if (result)
        {
            vehicleSlotMap[vehicle.LicensePlate] = (floor, slot);
            Console.WriteLine($"Parked at Floor {floor}, Slot {slot}");
        }
        return result;
    }

    public bool UnparkVehicle(string licensePlate)
    {
        if (vehicleSlotMap.TryGetValue(licensePlate, out var loc))
        {
            bool result = parkingLot.Unpark(loc.floor, loc.slot);
            vehicleSlotMap.Remove(licensePlate);
            Console.WriteLine($"Unparked vehicle {licensePlate} from Floor {loc.floor}, Slot {loc.slot}");
            return result;
        }
        Console.WriteLine("Vehicle not found");
        return false;
    }

    public void DisplayFreeSlots()
    {
        parkingLot.DisplayAvailability();
    }
}

//              ## 🌐 6. **If Exposed as REST APIs (Optional)**

// If building a Web API or Mobile App backend, the following endpoints would be useful:

// | Endpoint | Method | Description |
// | --- | --- | --- |
// | `/park` | POST | Accepts vehicle type + plate, returns slot details or "Full" |
// | `/unpark/{plate}` | POST | Unparks a vehicle by plate |
// | `/status` | GET | Returns current free/occupied slot info |
// | `/slots/free` | GET | List all free slots per floor/type |



//                  ## 🔍 7. **Optional Enhancements**

// | Feature | Description |
// | --- | --- |
// | `Ticket` Class | Contains entry time, fee calculation |
// | `PaymentService` | Handle payment after unpark |
// | `Slot Allocation Heuristics` | Nearest slot, EV-priority, etc. |
// | `Database Integration` | Persist vehicle-slot-ticket info |
// | `Logging` | Track entry/exit events for audit/logs |



//                      ## 📌 Summary

// | Component | Status |
// | --- | --- |
// | Class Hierarchy | ✅ Clear & Extendable |
// | Multiple Floors | ✅ Supported |
// | Vehicle Types | ✅ Supported |
// | Realistic API Design | ✅ Included |
// | Scalable Entry Point | ✅ Via `ParkingManager` |
// | Ready for Web/Mobile | ✅ Easily extendable |



//  Great — let’s now **focus on interface-based design** and implement a **Strategy Pattern** for flexible slot allocation. This allows us to easily switch between different allocation algorithms (e.g., nearest slot, first-available, EV-priority, etc.).



//              ## 🧩 1. **Strategy Pattern for Slot Allocation**

//  ### 🔧 Define an Interface

public interface ISlotAllocationStrategy
{
    ParkingSlot? GetAvailableSlot(List<ParkingFloor> floors, VehicleType type);
}

//  ### 🚗 Strategy 1: First Available Slot

public class FirstAvailableSlotStrategy : ISlotAllocationStrategy
{
    public ParkingSlot? GetAvailableSlot(List<ParkingFloor> floors, VehicleType type)
    {
        foreach (var floor in floors)
        {
            var slot = floor.GetAvailableSlot(type);
            if (slot != null)
                return slot;
        }
        return null;
    }
}

//  ### 🏁 Strategy 2: Nearest Floor First (priority-based)
public class NearestFloorPriorityStrategy : ISlotAllocationStrategy
{
    public ParkingSlot? GetAvailableSlot(List<ParkingFloor> floors, VehicleType type)
    {
        return floors.OrderBy(f => f.FloorNumber)
                     .Select(f => f.GetAvailableSlot(type))
                     .FirstOrDefault(slot => slot != null);
    }
}

//              ## 🏗️ 2. **Modify ParkingLot to Use Strategy**

public class ParkingLot
{
    private List<ParkingFloor> floors;
    private ISlotAllocationStrategy allocationStrategy;

    public ParkingLot(int floorCount, int slotsPerFloor, ISlotAllocationStrategy strategy)
    {
        allocationStrategy = strategy;
        floors = new List<ParkingFloor>();
        for (int i = 0; i < floorCount; i++)
        {
            floors.Add(new ParkingFloor(i, slotsPerFloor));
        }
    }

    public bool Park(Vehicle vehicle, out int floorNumber, out int slotNumber)
    {
        var slot = allocationStrategy.GetAvailableSlot(floors, vehicle.Type);
        if (slot != null)
        {
            slot.ParkVehicle(vehicle);
            floorNumber = slot.FloorNumber;
            slotNumber = slot.SlotNumber;
            return true;
        }
        floorNumber = -1;
        slotNumber = -1;
        return false;
    }

    public bool Unpark(int floor, int slot)
    {
        return floors[floor].Unpark(slot);
    }

    public void DisplayAvailability()
    {
        foreach (var floor in floors)
            floor.DisplayFreeSlots();
    }
}

//          ## 🧬 3. **UML & Class Diagram: Updated Strategy Design**

//  ### 🔗 Key Additions:

// - Interface `ISlotAllocationStrategy`
// - Two concrete implementations:
//     - `FirstAvailableSlotStrategy`
//     - `NearestFloorPriorityStrategy`


//          ## ✅ Summary of Benefits

// | Feature | Benefit |
// | --- | --- |
// | Interface-based allocation | Plug & play strategies |
// | Strategy pattern | Open/Closed Principle for scalability |
// | Class separation | Clean SOLID architecture |
// | UML clarity | Ready for design interviews or presentations |

