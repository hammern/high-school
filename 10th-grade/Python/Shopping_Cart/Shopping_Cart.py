__author__ = "Nadav Hammer"
""" Asks the user to buy products from the product list.
    After the user finishes buying the products it calculates the total amount of money for the purchase
    and prints a receipt. """


def user_buy(products):
    """ Gets the product and the amount of the product from the user and enters it into a dict called shopping cart """
    print("Welcome user to Best Buy!\nHere is a list of our products! Please enter what product do you want and enter"
          " \"done\" when you finish buying our products!")
    for key in products:
        print(key, "- Price:", products[key])
    shopping_cart = {}
    product_input = ""
    while product_input != "done":
        product_input = input("Please enter your item: ")
        if product_input == "done":
            break
        elif product_input not in products:
            print("Item does not exist")
        else:
            num_of_product = input("Please enter how many item do you want: ")
            if num_of_product.isdigit():
                if product_input in shopping_cart:
                    shopping_cart[product_input] += int(num_of_product)
                else:
                    shopping_cart[product_input] = int(num_of_product)
            else:
                print("Must be a positive natural number")
    return shopping_cart


def calculate_total(shopping_cart, products):
    """ Calculate the user's total price """
    total = 0
    for product in shopping_cart:
        total += shopping_cart[product] * products[product]
    return total


def print_total_price(total, shopping_cart, products):
    """ Prints the user's total price """
    print("Here is your receipt!\n_____________________________")
    print("Item                   Price\n-----------------------------")
    for product in shopping_cart:
        print("{:15} {}@{}$\t{}$ ".format(product, shopping_cart[product], products[product],
                                          shopping_cart[product] * products[product]))
    print("Total: ${}\n_____________________________".format(total))


def main():
    products = {"TV": 500, "Keyboard": 400, "Mouse": 300, "Computer": 1000, "Internet Cable": 20, "Xbox": 250,
                "Playstation": 250, "Controller": 150, "Nintendo Switch": 800, "Tablet": 300}
    shopping_cart = user_buy(products)
    total = calculate_total(shopping_cart, products)
    print_total_price(total, shopping_cart, products)


if __name__ == '__main__':
    main()
