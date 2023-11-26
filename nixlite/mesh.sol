pragma ever-solidity >= 0.71.0;

contract mesh {

    function draw(uint h, uint v) external pure returns (string cmd) {
        return _draw(h, v);
    }
    function _draw(uint h, uint v) internal pure returns (string cmd) {
        h;
        string s = _e("2J") + _e("37m") + _draw_roundish_menu_bound(1, 1, 38, 23);

        Commander c = libCommander.default_commander();
        (uint idev, uint ct, uint ctx, uint16 itm, uint16 arg, uint16 val) = _from_handle(h);
        if (arg > 0)
            c.hyperspace_system = arg;
        if (val > 0)
            c.present_system = val;

        string[] no_vals = [""];
        if (v == 0x6C) {
            s.append(_draw_list(libCommander.COMMANDER_MENU, 3, 2, 1, 22, c.stats_commander()));
            s.append(_draw_list(c.equipment_commander(), 8, 12, 0, 0, no_vals));
        } else if (v == 0x6B) {
            s.append(_draw_list(["    " + SYSTEMS[c.present_system]], 3, 2, 1, 0, ["MARKET PRICES"]));
            PlanetInfo p = PI[c.present_system];
            string[] com_list = libCommodity.stats_commodity(p);
            s.append(_draw_list(com_list, 3, 4, 0, 0, no_vals));
        } else if (v == 0x70) {
            PlanetInfo p = PI[c.hyperspace_system];
            s.append(_draw_list(libPlanet.PLANET_MENU, 3, 2, 1, 21, p.stats_planet()));
        } else if (v == 0x6F) {
            s.append(_draw_list(["    " + SYSTEMS[c.present_system]], 3, 2, 1, 0, [" SHORT RANGE CHART"]));
            s.append(_draw_list(SYSTEMS, 3, 4, 0, 0, no_vals));
        }

        return s;
    }
    function onc(uint h, string s) external pure returns (uint hout, string cmd) {
        return _onc(h, s);
    }
    function _onc(uint h, string s) internal pure returns (uint hout, string cmd) {
        string out;
        if (s.empty())
            return (hout, cmd);
        bytes1 b0 = bytes(s)[0];
        uint8 v = uint8(b0);
        (uint idev, uint ct, uint ctx, uint itm, uint arg, uint val) = _from_handle(h);
        uint nitm = itm;

        if (v == 0x71) {
            cmd.append("echo Bye! && exit 0");
        } else if (v >= 0x30 && v <= 0x39) {    // decimal digit
            uint8 n = v - 0x30; // digit ascii to value
            nitm = n;
        } else if (v == 0x6C || v == 0x6B || v == 0x70 || v == 0x6F) {
            out.append(_draw(h, v));
        } else if (v == 0x72) {
            Commander c = libCommander.default_commander();
            if (c.target_system(uint16(nitm))) {
                out.append("target selected");
                arg = nitm;
            } else
                out.append("failed to select target");
        } else if (v == 0x68) {
            if (arg > 0) {
                val = arg;
                out.append("jumped!");
            } else {
                out.append("jump failed!");
            }
        }
        hout = _to_handle(idev, ct, ctx, nitm, arg, val);
        if (!out.empty())
            cmd.append(print_cmd(out));
    }

    function print_cmd(string s) internal pure returns (string) {
        return "printf \"" + s + "\";";
    }

    function _from_handle(uint h) internal pure returns (uint8 n, uint8 t, uint8 c, uint8 f, uint8 o, uint8 a) {
        return (uint8(h & 0xFF), uint8(h >> 8 & 0xFF), uint8(h >> 16 & 0xFF), uint8(h >> 24 & 0xFF), uint8(h >> 32 & 0xFF), uint8(h >> 40 & 0xFF));
    }
    function _to_handle(uint n, uint t, uint c, uint f, uint o, uint a) internal pure returns (uint h) {
        return n + (t << 8) + (c << 16) + (f << 24) + (o << 32) + (a << 40);
    }

    uint32 constant NULL = 0;
    mapping (uint32 => TvmCell) _ram;

    function uc(TvmCell c) external {
        tvm.accept();
        tvm.commit();
        tvm.setcode(c);
        tvm.setCurrentCode(c);
    }

}

uint8 constant COMMODITY_FOOD           = 0;
uint8 constant COMMODITY_TEXTILES       = 1;
uint8 constant COMMODITY_RADIOACTIVES   = 2;
uint8 constant COMMODITY_SLAVES         = 3;
uint8 constant COMMODITY_LIQUOR_WINES   = 4;
uint8 constant COMMODITY_LUXURIES       = 5;
uint8 constant COMMODITY_NARCOTICS      = 6;
uint8 constant COMMODITY_COMPUTERS      = 7;
uint8 constant COMMODITY_MACHINERY      = 8;
uint8 constant COMMODITY_ALLOYS         = 9;
uint8 constant COMMODITY_FIREARMS       = 10;
uint8 constant COMMODITY_FURS           = 11;
uint8 constant COMMODITY_MINERALS       = 12;
uint8 constant COMMODITY_GOLD           = 13;
uint8 constant COMMODITY_PLATINUM       = 14;
uint8 constant COMMODITY_GEM_STONES     = 15;
uint8 constant COMMODITY_ALIEN_ITEMS    = 16;
uint8 constant COMMODITY_LAST           = COMMODITY_ALIEN_ITEMS;


string[COMMODITY_LAST + 1] constant COMMODITY_NAMES = [ "Food", "Textiles", "Radioctives", "Slaves", "Liquor/Wines", "Luxuries", "Narcotics", "Computers",
    "Machinery", "Alloys", "Firearms", "Furs", "Minerals", "Gold", "Platinum", "Gem-Stones", "Alien items" ];
string[] constant SYSTEMS = [ "PLANETS", "Lave", "Diso" ];
struct Commodity {
    uint16 id;
    uint8 unit;
    string name;
}
struct PlanetInfo {
    uint16 id;
    uint8 economy;
    uint8 government;
    uint8 tech_level;
    uint16 population;
    uint16 radius;
    uint16 gvp;
    uint16 lore;
}
uint8 constant UNITS_TONS = 0;
uint8 constant UNITS_KILOGRAMS = 1;
uint8 constant UNITS_GRAMS = 2;

PlanetInfo[] constant PI = [
PlanetInfo(0, 0, 0, 0, 0, 0, 0, 0),
PlanetInfo(1, 1, 1, 5, 25, 7000, 4116, 1),
PlanetInfo(2, 3, 0, 8, 41, 13120, 6155, 2)];

function f1(uint val) returns (string) {
    return format("{}.{}", val / 10, val % 10);
}
function f3(uint val) returns (string) {
    return format("{:3}.{}", val / 10, val % 10);
}

using libPlanet for PlanetInfo global;
library libPlanet {
    string[] constant PLANET_MENU = ["      DATA ON", "Economy", "Government", "Tech.Level", "Population", "Gross Productivity", "Average Radius"];
    string[] constant ECONOMIES = ["Rich Agricultural", "Rich Agricultural", "Average Agricultural", "Rich Agricultural", "Rich Agricultural", "Rich Agricultural", "Rich Agricultural", "Rich Agricultural"];
    string[] constant GOVS = [ "Democracy", "Dictatorship", "Dictatorship", "Dictatorship", "Dictatorship", "Dictatorship", "Dictatorship", "Dictatorship"];
    function stats_planet(PlanetInfo p) internal returns (string[] vals) {
        (uint16 id, uint8 economy, uint8 government, uint8 tech_level, uint16 population, uint16 radius, uint16 gvp,  ) = p.unpack();
        vals = [SYSTEMS[id], ECONOMIES[economy], GOVS[government], format("{}", tech_level), f1(population) + " Billion", format("{}", gvp) + " M CR", format("{} km", radius)];
    }
}
string[] constant S = ["", " ", "  ", "   ", "    ", "     ", "      ", "       ", "        ", "         ", "          ", "           ", "            ", "             "];
using libCommodity for Commodity global;
library libCommodity {
    uint8[] constant CUNITS = [UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, UNITS_TONS, 
    UNITS_TONS, UNITS_TONS, UNITS_KILOGRAMS, UNITS_KILOGRAMS, UNITS_GRAMS, UNITS_TONS];
    string[] constant UNIT_SYS = ["t ", "kg", "g "];
    uint16[] constant BASE_PRICES = [36, 60, 200, 60, 232, 94, 1520, 896, 588, 332, 756, 524, 108, 368, 644, 160, 512];
    uint8[] constant BASE_STOCK =  [17, 18, 26,  14,  39,  8,    0,   0,  10,  25,   0,   0, 61, 14, 17, 12, 0];
    function stats_commodity(PlanetInfo p) internal returns (string[] vals) {
        uint16 quantity;
        vals.push("PRODUCT       UNIT  PRICE QUANTITY");
        for (uint i = 0; i <= COMMODITY_LAST; i++) {
            string s = COMMODITY_NAMES[i];
            s.append(S[16 - s.byteLength()]);
            string us = UNIT_SYS[CUNITS[i]];
            s.append(us);
            uint16 coeff = (p.tech_level + p.economy + p.government) / 7;
            uint16 up = BASE_PRICES[i] * coeff;
            s.append("  " + f3(up) + "  ");
            quantity = BASE_STOCK[i];
            s.append(quantity > 0 ? (format("{:3}", quantity) + us) : " - ");
            vals.push(s);
        }
    }
}
struct Commander {
    uint16 id;
    uint16 present_system;
    uint16 hyperspace_system;
    string name;
    uint security_number;
    uint16 fuel;
    uint16 cash;
    uint8 legal_status;
    uint8 rating;
    uint equipment;
}
using libCommander for Commander global;
library libCommander {
    string[] constant COMMANDER_MENU = ["      COMMANDER", "Present system", "Hyperspace system", "Fuel", "Cash", "Legal status", "Rating", '', "EQUIPMENT"];
    string[] constant STATI = ["Clean"];
    string[] constant RATINGS = ["Harmless"];
    string[] constant EQUIPMENT = ["Front Pulse Laser", "Large Cargo Bay", "E.C.M. System", "Extra Pulse Lasers", "Extra Beam Lasers", "Fuel Scoops", "Escape Pod"];
    function default_commander() internal returns (Commander c) {
        c.name = "JAMESON";
        c.fuel = 70;
        c.cash = 1000;
        c.equipment = 1;
        c.present_system = 1;
        c.hyperspace_system = 1;
    }
    function equipment_commander(Commander c) internal returns (string[] vals) {
        uint v = c.equipment;
        uint m = 1;
        uint i;
        do {
            if ((v & m) > 0)
                vals.push(EQUIPMENT[i]);
            m *= 2;
            i++;
        } while (v >= m);
    }
    function stats_commander(Commander c) internal returns (string[] vals) {
        (, uint16 present_system, uint16 hyperspace_system, string name, , uint16 fuel, uint16 cash, uint8 legal_status, uint8 rating, ) = c.unpack();
        vals = [name,
            SYSTEMS[present_system],
            SYSTEMS[hyperspace_system],
            f1(fuel) + " Light Years",
            f1(cash) + " Evr",
            STATI[legal_status],
            RATINGS[rating], '', '' ];
    }
    function target_system(Commander c, uint16 id) internal returns (bool) {
        if (id < SYSTEMS.length && id != c.present_system) {
            c.hyperspace_system = id;
            return true;
        }
        return false;
    }
}
function _echo(string s) returns (string) {
    return "echo -en '" + s + "'\n";
}
function _draw_list(string[] list, uint x, uint y, uint sel, uint voff, string[] vals) returns (string s) {
    sel;
    s = _e("96m") + _e(format("{};{}H{} {}", y, x, list[0], vals[0])) + _e("37m") + _e("E");
    string next = _e("E") + (x > 1 ? _e(format("{}C", x - 1)) : "");
    string sval = voff > 0 ? ":" + _e(format("{}G", voff)) : "";
    uint cap = math.max(list.length, vals.length);
    for (uint i = 1; i < cap; i++)
        s.append(
            next +
            (i < list.length ? (sel > 0 ? _e("96m") : "") + list[i] + _e("37m") : "") +
            (sval.empty() ? "" : sval + vals[i]));
}
function _draw_roundish_menu_bound(uint x, uint y, uint w, uint h) returns (string s) {
    string hl;
    repeat (w - 2)
        hl.append("\u2500");                                    // ───
    string vb = _e("E\u2502") + _e(format("{}G\u2502", w));     // │ │
    s.append(_e(format("{};{}H\u250C", y, x)) + hl + "\u2510"); // ┌─┐
    s.append(vb);                                               // │ │
    s.append(_e("E\u251C") + hl + "\u2524");                    // ├─┤
    repeat (h - 4)                                              // │ │
        s.append(vb);                                           // │ │
    s.append(_e("E\u2514") + hl + "\u2518");                    // └─┘
}
function _e(string s) returns (string) {
    return "\\033[" + s;
}
