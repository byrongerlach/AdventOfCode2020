# Advent of Code Day 13
# https://adventofcode.com/2020/day/13

# Problem 1: Find bus that departs closest to the target time
import math

#Example 1
targetTime = 939
bus = 59
steps = math.ceil(targetTime/bus)
total = bus*steps
print (f"Nearest departure after target: {total}")

line = "7,13,x,x,59,x,31,19"
tokens = line.split(",")

#Finds the time you'll wait for the bus to depart (diff of departure time and target time)
def getWaitTime(bus):
    return getNearestDeparture(bus)-targetTime

#Gets nearest departure time after the target time
def getNearestDeparture(bus):
    busVal = int(bus)
    steps = math.ceil(targetTime/busVal)
    return busVal*steps

nearestWait = 0
nearestBus = "none"

dataLines = open('Day13Input.txt').readlines()
targetTime = int(dataLines[0])
busTokens = dataLines[1].split(',')

for bus in busTokens:
    if bus == "x":
        continue
    nearest = getWaitTime(bus)
    
    if nearestBus == "none":
        nearestBus = bus
        nearestWait = nearest
    if nearest < nearestWait:
        nearestBus = bus
        nearestWait = nearest

print ("Problem 1 solution:")   
print (f"Nearest Bus: {nearestBus} Wait Time :{nearestWait} Nearest Departure Time:{getNearestDeparture(nearestBus)}")
print (f"Nearest Bus * wait time : {int(nearestBus) * nearestWait}")

