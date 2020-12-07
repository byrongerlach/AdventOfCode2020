# Solutions for Advent of Code Day 6: https://adventofcode.com/2020/day/6

# Problem 1
# For each group, count the number of questions to which anyone answered "yes". What is the sum of those counts?
from collections import Counter

# Read the ilnes from the file. Each group's responses are
# separated by a blank line. 
with open("./Day6Problem1Input.txt") as dataFile:
    dataLines = dataFile.read()[:-1].split("\n\n")

#Count all answers that are not newline characters
total = sum(answer != "\n" 
    #Count is a counter for each line
    for counter in map(Counter, dataLines)
    #Answer is the key for the counter 
    for answer in counter)
print (f"Part 1 Total Answers: {total}")

# Problem 2
# For each group, count the number of questions to which everyone answered "yes". What is the sum of those counts?
# If the 
def everyoneAnswered (counter, answer):
    # Each person's answers are on one line, so the number of 
    # lines is equal to the number of people +1 since the newline
    # is missing from the last line.
    people = counter.get("\n",0)+1
    return (counter[answer] == people)

total = sum(everyoneAnswered(count, answer) 
    for count in map(Counter, dataLines) 
    for answer in count)
    
print (f"Part 2 Total Answers: {total}")