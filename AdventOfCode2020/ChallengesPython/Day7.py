# Advent of Code Day 7
# https://adventofcode.com/2020/day/7

# Problem 1: Find how many bags can contain a gold bag.

# Bags are identified by color. The rules for what bags other bags can hold are in one of these formats:
# vibrant cyan bags contain 4 dim tomato bags, 1 dull green bag, 5 light silver bags, 2 striped gold bags.
# pale yellow bags contain no other bags.

from collections import namedtuple
from collections import defaultdict
import re

BagRule = namedtuple('BagRule', 'number, color')

# Dictionary of bag rules. Index: color, Value: BagRule
bagRules = {}

# Dictionary of lists of bags in which a given bag is contained. Index: color, Value: List of colors
# Using defaultdict makes this easier when appending bags to a list that doesn't yet exist
bagsContainedIn = defaultdict(list)

def getBagRules(ruleString):
    bagRules = []
    bagRuleTuples = re.findall(r'(\d+) ([^\.,]+) bags?', ruleString)
    for bagRuleTuple in bagRuleTuples:
        bagRules.append(BagRule(number = bagRuleTuple[0], color = bagRuleTuple[1]))
    return bagRules

# Read each data line
for dataLine in open('Day7Problem1Input.txt').readlines():
#Color is first token, bag capacity rule string is second
    bag, contents = dataLine.split(" bags contain ")
    if contents == " no other bags.":
        continue
    bagRules[bag] = getBagRules(contents)

    for bagRule in bagRules[bag]:
        bagsContainedIn[bagRule.color].append(bag)
 
# Gets a set of all bags that can contain this bag
def getBagsContainedInSet(bag, bagSet):
    # Get the list of bags that can contain this bag
    if bagsContainedIn[bag]:
        for b in bagsContainedIn[bag]:
            bagSet.add(b)
            bagSet = getBagsContainedInSet(b, bagSet)
    return bagSet

#Problem 1 Solution: Find how many bags can contain a gold bag.
bagsContainedInSet = set()
bagsContainedInSet = getBagsContainedInSet("shiny gold", bagsContainedInSet)

print (len(bagsContainedInSet))