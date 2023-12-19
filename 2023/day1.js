const fs = require('fs');
const getData = fs.readFileSync('./data/day1.txt', 'utf-8');
const data = getData.split('\n');

// Part 1
const testArrayOne = ['1abc2', 'pqr3stu8vwx', 'a1b2c3d4e5f', 'treb7uchet']; // Should be 77

let getNumbersFromLine = (array) => {
	count = 0;

	let getOnlyNumbersInString = array.map((line) => {
		let number = line.replace(/\D/g, '');

		if (number < 10) {
			number = number * 10 + number;
		}

		if (number.length > 2) {
			let first = number.slice(0, 1);
			let second = number.slice(-1);
			let calibrationNumber = [first, second].join('');
			number = parseInt(calibrationNumber);
		}
		count = count + parseInt(number);
	});

	console.log(count); //56049 *
};

getNumbersFromLine(data);

// Part 2
const testArrayTwo = [
	'two1nine',
	'eightwothree',
	'abcone2threexyz',
	'xtwone3four',
	'4nineeightseven2',
	'zoneight234',
	'7pqrstsixteen',
]; // Should be 281

const wordsOfNumbers = {
	one: 'o1e',
	two: 't2o',
	three: 't3e',
	four: 4,
	five: 'f5e',
	six: 6,
	seven: 's7n',
	eight: 'e8t',
	nine: 'n9e',
};

replaceWordsWithNumbers = (line) => {
	return line.replace(
		/(one|two|three|four|five|six|seven|eight|nine)/g,
		(match) => wordsOfNumbers[match]
	);
};

getNewNumbersFromLines = (array) => {
	let count = 0;

	array.forEach((line) => {
		let defaultLine = line;
		let changed = false;

		do {
			line = replaceWordsWithNumbers(line);
			changed = line !== defaultLine;
			defaultLine = line;
		} while (changed);

		let number = line.replace(/\D/g, '');
		if (number < 10) {
			number = number * 10 + number;
		}

		if (number.length > 2) {
			let first = number.slice(0, 1);
			let second = number.slice(-1);
			let calibrationNumber = [first, second].join('');
			number = parseInt(calibrationNumber);
		}
		count += parseInt(number);
	});
	console.log(count); // 54530
};

getNewNumbersFromLines(data);
