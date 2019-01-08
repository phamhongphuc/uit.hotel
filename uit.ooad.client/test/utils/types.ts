export interface VueProcess extends NodeJS.Process {
    server: boolean;
    client: boolean;
}
