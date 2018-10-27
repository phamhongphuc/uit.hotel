import path from 'path';
import chalk from 'chalk';
/**
 *
 * @param {String} name
 */
const root = process.cwd();
export function filename(name) {
    return chalk.bold.magenta(path.relative(root, name));
}

/**
 *
 * @param {String} method
 * @param {String} description
 */
export function itname(method, description) {
    const log = ` ${method} `
        .replace(/ ([A-Z][a-z]+)(?=\.)/, ` ${chalk.bold.green('$1')}`)
        .replace(/\.([a-z]\w+)(?=\s)/, `.${chalk.bold.yellow('$1 ')}`)
        .replace(/ (\.[a-z]\w+\(\))(?=\s)/, ` ${chalk.cyan('$1')}`)
        .trim();
    return `${chalk.bold.blue(log)} ${chalk.gray(description)}`;
}
