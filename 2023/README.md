# Overview/Notes

The goal is to complete as many as I can once again this year.

### Day 1

The first part of day 1 was smooth, then I thought I had day 2 figured out after I spent a while figuring out the REGEX. The plan was to just convert one to 1, two to 2, etc... but that didn't work because of a few edge cases like 'oneight' and what I was doing would turn that to '1ight' instead of '18'. So instead of changing it to a full number I added the number while keeping the first and last letter. Then running that regex as many times as needed the lines so it would change all the words needed to numbers. That part took me the longest, because of how long it took me to discover the edge cases. In the end I was able to solve the puzzle, and that was the goal.
