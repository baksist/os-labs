import datetime as dt

a = 0
b = 2
c = 3
iterations = 100000000

start = dt.datetime.now()

for i in range(iterations):
    a += b * 2 + c - i

end = dt.datetime.now()

exec_time = ((end - start).seconds * 1000000 + (end-start).microseconds) / 1000000
print(f'Python: {exec_time} seconds')

