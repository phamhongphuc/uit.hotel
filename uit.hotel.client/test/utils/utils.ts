import * as path from 'path';
import chalk from 'chalk';

const root = process.cwd();
export function filename(name: string): string {
    return chalk.bold.magenta(path.relative(root, name));
}

export function itname(method: string, description: string): string {
    const log = ` ${method} `
        .replace(/ ([A-Z][a-z]+)(?=\.)/, ` ${chalk.bold.green('$1')}`)
        .replace(/\.([a-z]\w+)(?=\s)/, `.${chalk.bold.yellow('$1 ')}`)
        .replace(/ (\.[a-z]\w+\(\))(?=\s)/, ` ${chalk.cyan('$1')}`)
        .trim();
    return `${chalk.bold.blue(log)} ${chalk.gray(description)}`;
}
