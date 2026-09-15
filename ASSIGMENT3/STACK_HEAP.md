# Stack and Heap

## Diagram 1 — After line 1

```text
STACK                    HEAP
+----------+             +----------------------+
| o1       | ----------> | Order                |
| 0x100    |             | OrderId = 1          |
+----------+             | CustomerName = "Ali" |
                         | IsPaid = false       |
                         +----------------------+

## Diagram 2 — After line 2
 STACK                    HEAP
+----------+             +----------------------+
| o1       | -----+      | Order                |
| 0x100    |      |----> | OrderId = 1          |
+----------+      |      | CustomerName = "Ali" |
                  |      | IsPaid = false       |
+----------+      |      +----------------------+
| o2       | -----+
| 0x100    |
+----------+

## Diagram 3 — After line 3
STACK                    HEAP
+----------+             +----------------------+
| o1       | -----+      | Order                |
| 0x100    |      |----> | OrderId = 1          |
+----------+      |      | CustomerName = "Ali" |
                  |      | IsPaid = true        |
+----------+      |      +----------------------+
| o2       | -----+
| 0x100    |
+----------+

o2.IsPaid = true changes the same heap object that both o1 and o2 point to.


## Struct Depend on value Type not reference Type
a struct assigning one variable to another copies the value,

STACK
+----------+     +----------+
| s1       |     | s2       |
| IsPaid   |     | IsPaid   |
| false    |     | false    |
+----------+     +----------+