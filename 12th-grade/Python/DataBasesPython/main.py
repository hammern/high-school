__author__ = "Nadav Hammer"
""" Database with python """

import sqlite3


def print_all_db(cur):
    """ Prints all the database """
    cur.execute("SELECT * FROM Cars")
    for row in cur:
        print(row)


def print_db(cur):
    """ Prints database if selection was made prior """
    for row in cur:
        print(row)


def add_cars(cur):
    """ Adds 5 cars to the database """
    cur.execute("INSERT INTO Cars(CarNumber, Year, Manufacturer, Country, Color, Volume) VALUES (?, ?, ?, ?, ?, ?)",
                ("20364353", 2015, "Toyota", "Japan", "White", 1150))
    cur.execute("INSERT INTO Cars(CarNumber, Year, Manufacturer, Country, Color, Volume) VALUES (?, ?, ?, ?, ?, ?)",
                ("30547678", 2015, "Hyundai", "Japan", "Red", 1250))
    cur.execute("INSERT INTO Cars(CarNumber, Year, Manufacturer, Country, Color, Volume) VALUES (?, ?, ?, ?, ?, ?)",
                ("24692562", 2016, "Toyota", "United States", "Green", 1350))
    cur.execute("INSERT INTO Cars(CarNumber, Year, Manufacturer, Country, Color, Volume) VALUES (?, ?, ?, ?, ?, ?)",
                ("91362294", 2017, "Volkswagen", "Germany", "Blue", 1450))
    cur.execute("INSERT INTO Cars(CarNumber, Year, Manufacturer, Country, Color, Volume) VALUES (?, ?, ?, ?, ?, ?)",
                ("54803029", 2018, "Subaru", "Japan", "Cyan", 1550))
    print_all_db(cur)


def year_2015(cur):
    """ Selects and prints all the cars that were manufactured in the year 2015 """
    cur.execute("SELECT * FROM Cars WHERE Year = '2015'")
    print_db(cur)


def color_white(cur):
    """ Selects and prints all the cars that are colored white """
    cur.execute("SELECT * FROM Cars WHERE Color = 'White'")
    print_db(cur)


def year_before_2015_and_volume_less_than_1600(cur):
    """ Selects and prints all the cars that were manufactured before the year 2015
     and with a volume of less than 1600 """
    cur.execute("SELECT * FROM Cars WHERE Year < '2015' and volume < '1600'")
    print_db(cur)


def delete_older_than_10(cur):
    """ Deletes all of the cars which are older than 10 (manufactured before 2010)
     and then prints the database """
    cur.execute("DELETE FROM Cars WHERE Year <= '2010'")
    print_all_db(cur)


def main():
    db = sqlite3.connect("Cars")
    cur = db.cursor()

    # 1: Print all cars
    print("1:")
    print_all_db(cur)

    # 2: Add 5 cars
    print("2:")
    add_cars(cur)

    # 3: Manufactured in 2015
    print("3:")
    year_2015(cur)

    # 4: White color
    print("4:")
    color_white(cur)

    # 5: Manufactured before 2015 and volume is less than 1600
    print("5:")
    year_before_2015_and_volume_less_than_1600(cur)

    # 6: Delete cars older than 10
    print("6:")
    delete_older_than_10(cur)

    # If you want to save the data to the database remove the comment "db.commit()".
    # I don't commit right now because I want to keep the database the same every time I run the code.

    # db.commit()

    db.close()


if __name__ == '__main__':
    main()
