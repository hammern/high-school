# Fibonacci series until 10000
a = 0
b = 1
c = a + b
while c < 10000:
    if a == 0:
        a = 1
        print(a)
        b = a
        print(b)
    else:
        a = b
        b = c
        c = a + b
        print(c)

# Jumps of 0.1 with full numbers being displayed without decimal point.
for i in range(0, 51):
    if i % 10 == 0:
        i = i / 10
        print(int(i))
    else:
        i = i / 10
        print(i)
