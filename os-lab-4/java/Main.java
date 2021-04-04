public class Main {

    public static void main(String[] args) {
        int a = 0;
        int b = 2;
        int c = 3;
        long iterations = 100000000l;
        long start = System.currentTimeMillis();
        long end;
        float exec_time;

        for (int i = 0; i <= iterations; i++)
            a += b * 2 + c - i;

        end = System.currentTimeMillis();

        exec_time = (float)(end - start) / 1000;

        System.out.println("Java: " + exec_time + " seconds");
    }
}
