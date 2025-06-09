from scapy.all import *

def http_get_filter(packet):
    return (TCP in packet and Raw in packet and packet[Raw].load.startswith(b'GET'))

def print_http_url(packet):
    req = packet[Raw].load.split(b'\r\n')

    for r in req[1:]:
        if r:
            values = r.split(b':')
            if values[0] == b'Host':
                print(r.decode())

sniff(count=1, lfilter=http_get_filter, prn=print_http_url)