export interface Gateway {
    id: number;
    ip: string;
    serialNumber: string;
    name: string;
    devices: Device[];
}

interface Device {
    id: number;
    vendor: string;
    createdDate: string;
    status: string;
}